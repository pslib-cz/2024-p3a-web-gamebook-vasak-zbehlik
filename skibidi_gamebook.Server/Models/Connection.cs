using System.ComponentModel.DataAnnotations.Schema;

namespace skibidi_gamebook.Server.Models
{
    public class Connection
    {

        public int Id { get; set; }
        public int FromId { get; set; }
        public int ToId { get; set; }
        public string Lock { get; set; }
        public int RequirementsId { get; set; }

        [ForeignKey("FromId")]
        public Room From { get; set; }
        [ForeignKey("ToId")]
        public Room To { get; set; }
        [ForeignKey("RequirementsId")]
        public Achivement Requirements { get; set; }
    }
}
