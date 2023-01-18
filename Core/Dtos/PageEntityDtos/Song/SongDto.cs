using Core.Dtos.PageEntity.Singer;
using Core.Models.CommonEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.PageEntity.Song
{
    public class SongDto:BaseEntity
    {
        public SongDto()
        {

        }
        public SongDto(string name, int releaseDate, string kind, int singerId, SingerNavigationDto singer)
        {
            Name = name;
            ReleaseDate = releaseDate;
            Kind = kind;
            SingerId = singerId;
            Singer = singer;
        }

        public string Name { get; set; }
        public int ReleaseDate { get; set; }
        public string Kind { get; set; } //Tarz
        public int SingerId { get; set; }
        public  SingerNavigationDto Singer { get; set; }
    }
}
