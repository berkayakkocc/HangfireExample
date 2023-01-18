using Core.Models.CommonEntity;

namespace Core.Models.Entity
{
    public class Song : BaseEntity
    {
        public string Name { get; set; }
        public int ReleaseDate { get; set; }
        public string Kind { get; set; } //Tarz
        public int SingerId { get; set; }
        public Singer Singer { get; set; }
    }
}
