namespace API.Controllers
{
    using Core.Dtos.GenericDto;
    using Core.Dtos.PageEntity.Singer;
    using Core.Dtos.PageEntity.Song;
    using Core.Dtos.PageEntityDtos.Song;
    using Core.Interfaces.PageInterface;
    using Microsoft.AspNetCore.Mvc;

    namespace Application.Controllers
    {
        [Route("api/songController", Order = 0)]
        public class SongController : Controller
        {
            private readonly ISongService _songService;

           

            [HttpPost]
            [Route("create-song")]
            public async Task<GenericResponseDto<NoContent>> CreateEntity([FromBody] GenericInputDto<CreateSongDto> tEntity)
            {
                return await _songService.CreateEntity(tEntity);
            }
            [HttpDelete]
            [Route("delete-song")]
            public async Task<GenericResponseDto<NoContent>> DeleteEntity([FromBody] GenericInputDto<DeleteSongDto> genericInputDto)
            {
                return await _songService.DeleteEntity(genericInputDto);
            }
            [HttpPut]
            [Route("update-song")]
            public async Task<GenericResponseDto<NoContent>> UpdateEntity([FromBody] GenericInputDto<UpdateSongDto> tEntity)
            {
                return await _songService.UpdateEntity(tEntity);
            }



            [HttpGet]
            [Route("get-all-song")]
            public GenericResponseDto<List<SongDto>> GetManyEntity(GenericInputDto<NoContent> tEntity)
            {
                return _songService.GetManyEntity(tEntity);
            }

            [HttpGet]
            [Route("get-by-id-song")]
            public Task<GenericResponseDto<SongDto>> GetByIdEntity(long id)
            {
                return _songService.GetByIdEntity(id);
            }






        }
    }

}
