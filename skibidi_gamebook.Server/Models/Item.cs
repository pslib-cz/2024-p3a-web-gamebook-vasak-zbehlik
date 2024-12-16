using System.ComponentModel.DataAnnotations;

namespace skibidi_gamebook.Server.Models
{
    public class Item
    {
        [Key]
        public int IId { get; set; } // PK
        public string Name { get; set; }
        public int Count { get; set; }
        public string Description { get; set; }
        public string Img { get; set; }

    }
}
