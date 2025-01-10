using System.ComponentModel.DataAnnotations;

namespace skibidi_gamebook.Server.Models
{
    public class Room
    {
        [Key]
        public int RId { get; set; } // PK
        public string Name { get; set; }
        public string? type { get; set; }
        public string Description { get; set; }
        public string? Img { get; set; }
        public string? charName { get; set; }
        public string? charImg { get; set; }
        public string? chartext { get; set; }
        //

    }
}
