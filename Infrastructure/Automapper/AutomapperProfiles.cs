using AutoMapper;
using Core.Dtos.PageEntity.Singer;
using Core.Dtos.PageEntity.Song;
using Core.Models.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Automapper
{
    public class AutomapperProfiles:Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Singer, CreateSingerDto>().ReverseMap();
            CreateMap<Singer, SingerDto>().ReverseMap();
            CreateMap<Singer, SingerNavigationDto>().ReverseMap();
            CreateMap<Singer, UpdateSingerDto>().ReverseMap();
            
            CreateMap<Song, CreateSongDto>().ReverseMap();
            CreateMap<Song, SongDto>().ReverseMap();
            CreateMap<Song, SongNavigationDto>().ReverseMap();
            CreateMap<Song, UpdateSongDto>().ReverseMap();



        }
    }
}
