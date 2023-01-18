using Core.Dtos.GenericDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.GenericInterface.CrudInterface
{
    public interface IBasicUpdateManyEntity<TInputEntity, TOutputEntity>
    {
        Task<GenericResponseDto<TOutputEntity>> UpdateManyEntity(GenericInputDto<List<TInputEntity>>? tEntities);
    }
}
