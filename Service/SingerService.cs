using AutoMapper;
using Core.Dtos.Constants;
using Core.Dtos.GenericDto;
using Core.Dtos.PageEntity.Singer;
using Core.Dtos.PageEntity.Song;
using Core.Interfaces.GenericInterface;
using Core.Interfaces.PageInterface;
using Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SingerService : ISingerService
    {
        private readonly IMapper _mapper;
        private IGenericCrudRepository<Singer> _iSingerCrudRepository;

        public SingerService(IMapper mapper, IGenericCrudRepository<Singer> iSingerCrudRepository)
        {
            _mapper = mapper;
            _iSingerCrudRepository = iSingerCrudRepository;
        }

        public async Task<GenericResponseDto<NoContent>> CreateEntity(GenericInputDto<CreateSingerDto> tEntity)
        {
            await _iSingerCrudRepository.Insert(_mapper.Map<Singer>(tEntity.Data));

            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnums.Success, null);
        }

        public async Task<GenericResponseDto<NoContent>> DeleteEntity(GenericInputDto<DeleteSingerDto>? genericInputDto)
        {
            await _iSingerCrudRepository.Delete((long)genericInputDto.Data.Id);
            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnums.Success, null);
        }

        public async Task<GenericResponseDto<SingerDto>> GetByIdEntity(long id)
        {
            Singer singer = await _iSingerCrudRepository.GetById(id);
            SingerDto singerDto = _mapper.Map<SingerDto>(singer);
            return GenericResponseDto<SingerDto>.ResponseData(singerDto, (int)ErrorEnums.Success, null);
        }

        public GenericResponseDto<List<SingerDto>> GetManyEntity(GenericInputDto<NoContent> tEntity)
        {
            List<Singer> singers = _iSingerCrudRepository.GetAll(tEntity.Skip, tEntity.Take /*tEntity.OrderedColumn, tEntity.OrderType*/).ToList();

            List<SingerDto> singerDtos = _mapper.Map<List<SingerDto>>(singers);
            return GenericResponseDto<List<SingerDto>>.ResponseData(singerDtos, (int)ErrorEnums.Success, null);
        }

        public async Task<GenericResponseDto<NoContent>> UpdateEntity(GenericInputDto<UpdateSingerDto> tEntity)
        {
            await _iSingerCrudRepository.Update(_mapper.Map<Singer>(tEntity.Data));
            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnums.Success, null);
        }
    }
}
