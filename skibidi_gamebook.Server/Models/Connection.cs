using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skibidi_gamebook.Server.Models
{
    public class Connection
    {
        [Key]
        public int CId { get; set; }
//        public int FromId { get; set; }
        public Room Room { get; set; }    //ToId
   
        public int Lock { get; set; }
        public Item? Item { get; set; }      //item needed to unlock
      

        public Achivement? Achivement { get; set; }        //achivement needed to unlock
    }
}
