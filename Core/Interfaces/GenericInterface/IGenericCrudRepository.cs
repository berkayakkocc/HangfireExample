using Core.Models.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.GenericInterface
{
    public interface IGenericCrudRepository<TEntity> where TEntity : BaseEntity
    {
        IQueryable<TEntity> GetAll(int skip = 0, int take = int.MaxValue /*string orderedColumn = "Id", string orderType = EntityOrderType.OrderAsc*/);
        Task<TEntity> GetById(long id);
        List<TEntity> GetByManyId(List<long?> ids, int skip = 0, int take = int.MaxValue /*string orderedColumn = "Id", string orderType = EntityOrderType.OrderAsc*/);
        Expression<Func<TEntity, bool>> NonDeleted();
        Task<TEntity> Insert(TEntity entity);
        Task<TEntity> InsertWithoutTransaction(TEntity entity);
        Task InsertManyEntity(List<TEntity> entity);
        Task InsertManyWithoutTransaction(List<TEntity> entity);
        Task Update(TEntity entity);
        void UpdateWithoutTransaction(TEntity entity, bool deleted = false);
        Task UpdateMany(List<TEntity> entities, bool deleted = false);
        void UpdateManyWithoutTransaction(List<TEntity> entities, bool deleted = false);
        Task Delete(long id);
        Task DeleteWithoutTransaction(long id);
        Task DeleteManyEntity(List<long?> ids);
        void DeleteManyWithoutTransaction(List<long?> ids);
      
        int GetPageCount();
        void CommitTransaction();
        Task CommitTransactionAsync();
        void RollbackTransactionAsync();
        void RollbackTransaction();

        //Task<List<Tout>> Pagination<Tout>(int page) where Tout : class, new();
        //IQueryable<TEntity> GetByEntityWithFilter(Expression<Func<TEntity, bool>> filter, int skip = 0, int take = int.MaxValue, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, IList<string> incudes = null);

    }
}
