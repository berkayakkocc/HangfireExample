using AutoMapper;
using Core.Interfaces.GenericInterface;
using Core.Models.CommonEntity;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Repositories.GenericRepositories
{
    public class GenericCrudRepository<TEntity> : IGenericCrudRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly HangfireExampleDbContext _context;
        private readonly IMapper _mapper;

        public GenericCrudRepository(HangfireExampleDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        #region Queries
        public IQueryable<TEntity> GetAll(int skip = 0, int take = int.MaxValue)
        {
            return _context.Set<TEntity>()
                                       // .AsNoTracking()
                                       .Where(NonDeleted())
                                       //.OrderBy((String.IsNullOrEmpty(orderedColumn) ? "Id" : orderedColumn) + " " + (String.IsNullOrEmpty(orderType) ? "ASC" : orderType))
                                       .Skip(skip)
                                       .Take(take == 0 ? int.MaxValue : take)
                                           .AsQueryable<TEntity>(); ;
        }
        public List<TEntity> GetByManyId(List<long?> ids, int skip = 0, int take = int.MaxValue)
        {
            List<TEntity> tEntity = _context.Set<TEntity>()
                                                        .AsNoTracking()
                                                        .Where(x => ids.Contains((int)x.Id))
                                                        .Where(NonDeleted())
                                                        //.OrderBy((String.IsNullOrEmpty(orderedColumn) ? "Id" : orderedColumn) + " " + (String.IsNullOrEmpty(orderType) ? "ASC" : orderType))
                                                        .Skip(skip)
                                                        .Take(take == 0 ? int.MaxValue : take)
                                                            .ToList();
            return tEntity;
        }

        public async Task<TEntity> GetById(long id) => await _context.Set<TEntity>()
                                                                   .Where(NonDeleted())
                                                                   .AsNoTracking()
                                                                   .FirstOrDefaultAsync(x => x.Id == id);

        public int GetPageCount()
        {
            return _context.Set<TEntity>().Where(NonDeleted()).Count();
        }
        public Expression<Func<TEntity, bool>> NonDeleted()
        {
            return tEntity => tEntity.Deleted != 1;
        }
        #endregion

        #region Transactions
        public void CommitTransaction()
        {
            _context.SaveChanges();
        }
        public async Task CommitTransactionAsync()
        {
            await _context.SaveChangesAsync();
        }
        public void RollbackTransactionAsync()
        {
            _context.Database.RollbackTransactionAsync();
        }
        public void RollbackTransaction()
        {
            _context.Database.RollbackTransactionAsync();
        }
        #endregion


        #region DeleteStatement
        public async Task Delete(long id)
        {
            //  TransactionControl(_transaction);
            TEntity entity = await GetById(id);
            if (entity == null) return;

            entity.Deleted = 1;
            entity.DeleteDate = DateTime.Now;
            entity.DeletedBy = 1;
            await this.Update(entity);
            // _transaction.Commit();
        }

        public async Task DeleteManyEntity(List<long?> ids)
        {
            // TransactionControl(_transaction);

            List<TEntity> entities = this.GetByManyId(ids);

            foreach (var item in entities)
            {
                item.DeleteDate = DateTime.Now;
                item.Deleted = 1;
                item.DeletedBy = 1;
            }

            await this.UpdateMany(entities, true);

            //_context.Set<TEntity>().RemoveRange(entities);
            // _context.SaveChanges();
            // _transaction.Commit();
        }

        public void DeleteManyWithoutTransaction(List<long?> ids)
        {
            List<TEntity> entities = this.GetByManyId(ids);

            foreach (var item in entities)
            {
                item.DeleteDate = DateTime.Now;
                item.Deleted = 1;
                item.DeletedBy = 1;
            }
            try
            {
                UpdateManyWithoutTransaction(entities, true);
                //_context.Set<TEntity>().RemoveRange(entities);
            }
            catch (Exception)
            {
                RollbackTransactionAsync();
            }
        }

        public async Task DeleteWithoutTransaction(long id)
        {
            try
            {
                TEntity entity = await GetById(id);
                entity.Deleted = 1;
                entity.DeleteDate = DateTime.Now;
                entity.DeletedBy = 1;
                this.UpdateWithoutTransaction(entity, true);
                //   _transaction.Commit();
            }
            catch (Exception)
            {
                RollbackTransactionAsync();
            }
        }
        #endregion





        #region Insert
        public async Task<TEntity> Insert(TEntity entity)
        {
            // TransactionControl(_transaction);
            entity.CreatedDate = DateTime.Now;
            entity.CreatedBy = 1;
            EntityEntry x = await _context.Set<TEntity>().AddAsync(entity);
            await _context.SaveChangesAsync();
            // await _transaction.CommitAsync();

            return (TEntity)x.Entity;
        }

        public async Task InsertManyEntity(List<TEntity> entity)
        {
            foreach (var item in entity)
            {
                item.CreatedDate = DateTime.Now;
                item.CreatedBy = 1;
            }

            await _context.Set<TEntity>().AddRangeAsync(entity);
            await _context.SaveChangesAsync();
            // await _transaction.CommitAsync();
        }

        public async Task InsertManyWithoutTransaction(List<TEntity> entity)
        {
            // TransactionControl(_transaction);
            try
            {
                foreach (var item in entity)
                {
                    item.CreatedDate = DateTime.Now;
                    item.CreatedBy = 1;
                }
                await _context.Set<TEntity>().AddRangeAsync(entity);
            }
            catch (Exception)
            {
                RollbackTransactionAsync();
            }

        }

        public async Task<TEntity> InsertWithoutTransaction(TEntity entity)
        {
            try
            {
                entity.CreatedDate = DateTime.Now;
                entity.CreatedBy = 1;
                EntityEntry x = await _context.Set<TEntity>().AddAsync(entity);

                return (TEntity)x.Entity;
            }
            catch (Exception)
            {
                RollbackTransactionAsync();
            }
            return null;
        }
        #endregion






        #region Update
        public async Task Update(TEntity entity)
        {
            entity.UpdatedDate = DateTime.Now;
            entity.UpdatedBy = 1;

            _context.Set<TEntity>().Update(entity);
            await _context.SaveChangesAsync();
            //  await _transaction.CommitAsync();
        }

        public async Task UpdateMany(List<TEntity> entities, bool deleted = false)
        {
            if (!deleted)
                foreach (var entity in entities)
                {
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = 1;
                }

            _context.Set<TEntity>().UpdateRange(entities);
            await _context.SaveChangesAsync();
        }

        public void UpdateManyWithoutTransaction(List<TEntity> entities, bool deleted = false)
        {
            if (!deleted)
            {
                foreach (var entity in entities)
                {
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = 1;
                }
            }
            try
            {
                _context.Set<TEntity>().UpdateRange(entities);
            }
            catch (Exception)
            {
                RollbackTransactionAsync();
            }
        }

        public void UpdateWithoutTransaction(TEntity entity, bool deleted = false)
        {
            try
            {
                if (!deleted)
                {
                    entity.UpdatedDate = DateTime.Now;
                    entity.UpdatedBy = 1;
                }
                _context.Set<TEntity>().Update(entity);
            }
            catch (Exception)
            {
                RollbackTransactionAsync();
            }
        }
        #endregion







    }
}
