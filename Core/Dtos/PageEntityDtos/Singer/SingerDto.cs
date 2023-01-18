using Core.Dtos.PageEntity.Song;
using Core.Models.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.PageEntity.Singer
{
    public class SingerDto:BaseEntity
    {
        public SingerDto()
        {

        }
        public SingerDto(string name, int bornDate, int age, ICollection<SongNavigationDto> songs)
        {
            Name = name;
            BornDate = bornDate;
            Age = age;
            Songs = songs;
        }

        public string Name { get; set; }
        public int BornDate { get; set; }
        public int Age { get; set; }

        public ICollection<SongNavigationDto> Songs { get; set; }
    }
}
