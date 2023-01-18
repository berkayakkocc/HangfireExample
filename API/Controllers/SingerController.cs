using Core.Dtos.GenericDto;
using Core.Dtos.PageEntity.Singer;
using Core.Interfaces.PageInterface;
using Microsoft.AspNetCore.Mvc;

namespace Application.Controllers
{
    [Route("api/singerController", Order = 0)]
    public class SingerController : Controller
    {
        private readonly ISingerService  _singerService;

        public SingerController(ISingerService singerService)
        {
            _singerService = singerService;
        }

        [HttpPost]
        [Route("create-singer")]
        public async Task<GenericResponseDto<NoContent>> CreateEntity([FromBody] GenericInputDto<CreateSingerDto> tEntity)
        {
            return await _singerService.CreateEntity(tEntity);
        }
        [HttpDelete]
        [Route("delete-singer")]
        public async Task<GenericResponseDto<NoContent>> DeleteEntity([FromBody] GenericInputDto<DeleteSingerDto> genericInputDto)
        {
            return await _singerService.DeleteEntity(genericInputDto);
        }
        [HttpPut]
        [Route("update-singer")]
        public async Task<GenericResponseDto<NoContent>> UpdateEntity([FromBody] GenericInputDto<UpdateSingerDto> tEntity)
        {
            return await _singerService.UpdateEntity(tEntity);
        }

       

        [HttpGet]
        [Route("get-all-singer")]
        public GenericResponseDto<List<SingerDto>> GetManyEntity(GenericInputDto<NoContent> tEntity)
        {
            return _singerService.GetManyEntity(tEntity);
        }

        [HttpGet]
        [Route("get-by-id-singer")]
        public Task<GenericResponseDto<SingerDto>> GetByIdEntity(long id)
        {
            return _singerService.GetByIdEntity(id);
        }

        

       
       

    }
}
