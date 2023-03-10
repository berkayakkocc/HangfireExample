using Core.Models.CommonEntity;

namespace Core.Models.Entity
{
    public class Song : BaseEntity
    {
        public Song()
        {

        }
        public Song(string name, int releaseDate, string kind, int singerId, Singer singer)
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
        public virtual Singer Singer { get; set; }
    }
}
