using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace skibidi_gamebook.Server.Models
{
    public class Character
    {
        [Key]
        public int CharacterId { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public string img {  get; set; }
        public int? whereId { get; set; }
        public Room? where { get; set; }
    }
}
