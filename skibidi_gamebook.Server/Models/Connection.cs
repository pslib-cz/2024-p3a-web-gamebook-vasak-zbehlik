using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace skibidi_gamebook.Server.Models
{
    public class Connection
    {
        [Key]
        public int CId { get; set; }
//        public int FromId { get; set; }
        public int RoomId { get; set; }    //ToId
   
        public int Lock { get; set; }
        public int? ItemId { get; set; }      //item needed to unlock
      

        public int? AchivementId { get; set; }        //achivement needed to unlock
    }
}
