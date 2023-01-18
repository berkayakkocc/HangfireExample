using Core.Dtos.GenericDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.GenericInterface.CrudInterface
{
    public interface IBasicGetByIdEntity<TInputEntity, TResponseEntity>
    {
        Task<GenericResponseDto<TResponseEntity>> GetByIdEntity(TInputEntity id);
    }
}
