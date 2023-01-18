using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dtos.PageEntity.Song
{
    public class CreateSongDto
    {
        public CreateSongDto()
        {

        }
        public CreateSongDto(string name, int releaseDate, string kind, int singerId)
        {
            Name = name;
            ReleaseDate = releaseDate;
            Kind = kind;
            SingerId = singerId;
        }

        public string Name { get; set; }
        public int ReleaseDate { get; set; }
        public string Kind { get; set; } //Tarz
        public int SingerId { get; set; }
    }
}
