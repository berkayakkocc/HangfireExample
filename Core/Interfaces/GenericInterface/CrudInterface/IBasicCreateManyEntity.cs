using Core.Dtos.GenericDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.GenericInterface.CrudInterface
{
    public interface IBasicCreateManyEntity<TEntity, TResponseEntity>
    {
        Task<GenericResponseDto<TResponseEntity>> CreateManyEntity(GenericInputDto<List<TEntity>> tEntities);
    }
}
