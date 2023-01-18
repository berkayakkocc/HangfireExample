using AutoMapper;
using Core.Dtos.Constants;
using Core.Dtos.GenericDto;
using Core.Dtos.PageEntity.Song;
using Core.Dtos.PageEntityDtos.Song;
using Core.Interfaces.GenericInterface;
using Core.Interfaces.PageInterface;
using Core.Models.Entity;
using Service.Repositories.GenericRepositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class SongService : ISongService
    {
        private readonly IMapper _mapper;
        private IGenericCrudRepository<Song> _iSongCrudRepository;

        public SongService(IMapper mapper, IGenericCrudRepository<Song> iSongCrudRepository)
        {
            _mapper = mapper;
            _iSongCrudRepository = iSongCrudRepository;
        }

        public async Task<GenericResponseDto<NoContent>> CreateEntity(GenericInputDto<CreateSongDto> tEntity)
        {
            await _iSongCrudRepository.Insert(_mapper.Map<Song>(tEntity.Data));

            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnums.Success, null);
        }

        public async Task<GenericResponseDto<NoContent>> DeleteEntity(GenericInputDto<DeleteSongDto>? genericInputDto)
        {
            await _iSongCrudRepository.Delete((long)genericInputDto.Data.Id);
            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnums.Success, null);
        }

        public async Task<GenericResponseDto<SongDto>> GetByIdEntity(long id)
        {
            Song song = await _iSongCrudRepository.GetById(id);
            SongDto songDto = _mapper.Map<SongDto>(song);
            return GenericResponseDto<SongDto>.ResponseData(songDto, (int)ErrorEnums.Success, null);
        }

        public GenericResponseDto<List<SongDto>> GetManyEntity(GenericInputDto<NoContent> tEntity)
        {
            List<Song> songs = _iSongCrudRepository.GetAll(tEntity.Skip, tEntity.Take /*tEntity.OrderedColumn, tEntity.OrderType*/).ToList();

            List<SongDto> songDtos = _mapper.Map<List<SongDto>>(songs);
            return GenericResponseDto<List<SongDto>>.ResponseData(songDtos, (int)ErrorEnums.Success, null);
        }

        public async Task<GenericResponseDto<NoContent>> UpdateEntity(GenericInputDto<UpdateSongDto> tEntity)
        {
            await _iSongCrudRepository.Update(_mapper.Map<Song>(tEntity.Data));
            return GenericResponseDto<NoContent>.ResponseData(new NoContent(), (int)ErrorEnums.Success, null);
        }
    }
}
