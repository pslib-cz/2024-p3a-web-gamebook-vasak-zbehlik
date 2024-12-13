namespace skibidi_gamebook.Server.Models
{
    public class Item
    {
        public int Id { get; set; } // PK
        public string Name { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }

        public ICollection<Connection> ConnectionsFrom { get; set; } = new List<Connection>();
        public ICollection<Connection> ConnectionsTo { get; set; } = new List<Connection>();
    }
}
