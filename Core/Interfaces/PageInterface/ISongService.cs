using Core.Dtos.GenericDto;
using Core.Dtos.PageEntity.Singer;
using Core.Dtos.PageEntity.Song;
using Core.Dtos.PageEntityDtos.Song;
using Core.Interfaces.GenericInterface.CrudInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces.PageInterface
{
    public interface ISongService :                   IBasicCreateEntity<CreateSongDto, NoContent>,
                                                      IBasicDeleteEntity<DeleteSongDto, NoContent>,
                                                      IBasicUpdateEntity<UpdateSongDto, NoContent>,

                                                      IBasicGetManyEntity<NoContent, List<SongDto>>,
                                                      IBasicGetByIdEntity<long, SongDto>
    {
    }
}
