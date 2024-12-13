namespace skibidi_gamebook.Server.Models
{
    public class Room
    {
        public int Id { get; set; } // PK
        public string Name { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }

        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
