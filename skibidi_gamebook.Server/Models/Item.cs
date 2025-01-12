using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace skibidi_gamebook.Server.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; } // PK
        public string Name { get; set; }
        public string? Description { get; set; }
        public string Img { get; set; }
        public int? RoomId { get; set; } //in what room you can find it
        [JsonIgnore]
        public Room? Rooms { get; set; }

        public Connection? Connection { get; set; } //where it is used

    }
}
