using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace skibidi_gamebook.Server.Models
{
    public class Room
    {
        [Key]
        public int RoomId { get; set; } // PK

        public string Name { get; set; }
        //        public int Count { get; set; }
        public string Description { get; set; }
        public string? Img { get; set; }


        public ICollection<Connection>? Connections { get; set; } // kam se da jit z tohoto roomu
        public ICollection<Item>? Items { get; set; }
        
        public Connection? Connection { get; set; } //co nas dovede do tohoto roomu 
        public Character? Character { get; set; }


    }
}
