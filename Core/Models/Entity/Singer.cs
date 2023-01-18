namespace Core.Models.Entity
{
    public class Singer
    {
        public string Name { get; set; }
        public int BornDate { get; set; }
        public int Age { get; set; }

        public ICollection<Song> Songs { get; set; }

    }
}
