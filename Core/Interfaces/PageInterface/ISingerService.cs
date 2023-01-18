using Core.Dtos.GenericDto;
using Core.Dtos.PageEntity.Singer;
using Core.Interfaces.GenericInterface.CrudInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.PageInterface
{
    public interface ISingerService :                  IBasicCreateEntity<CreateSingerDto, NoContent>,
                                                       IBasicDeleteEntity<DeleteSingerDto, NoContent>,
                                                       IBasicUpdateEntity<UpdateSingerDto, NoContent>,
                                                       
                                                       IBasicGetManyEntity<NoContent, List<SingerDto>>,
                                                       IBasicGetByIdEntity<long, SingerDto>
                                                      
    {
    }
}
