using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace skibidi_gamebook.Server.Models
{
    public class Connection
    {
        [Key]
        public int ConnectionId { get; set; }

        public string Name {  get; set; }  //co bude v buttonu
        public int Lock { get; set; }
        public int? RequieremenId { get; set; }      //item needed to unlock
        [JsonIgnore]
        public Item? Requierement { get; set; }       // item needded to unlock


        public int? FromId { get; set; }     // foreign key     v jakem roomu je
        [JsonIgnore]
        public Room? From { get; set; }      // navigation property

 
        public int? ToId { get; set; } // kam to vede
        [JsonIgnore]
        public Room? To { get; set; } // kam to vede
    }
}
