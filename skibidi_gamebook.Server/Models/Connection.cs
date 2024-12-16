using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skibidi_gamebook.Server.Models
{
    public class Connection
    {
        [Key]
        public int CId { get; set; }
//        public int FromId { get; set; }
        public Room Room { get; set; }
        public int RId { get; set; }        //ToId
        public string Lock { get; set; }
        public Item Item { get; set; }
        public int IId { get; set; }        //item needed to unlock

        public Achivement Achivement { get; set; }
        public int AId { get; set; }        //achivement needed to unlock
    }
}
