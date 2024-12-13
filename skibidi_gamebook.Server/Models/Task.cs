namespace skibidi_gamebook.Server.Models
{
    public class Task
    {
        public int Id { get; set; } // PK
        public string Name { get; set; }
        public int RequirementsId { get; set; } // FK to Achivement
        public bool Completed { get; set; }

        public Achivement Requirements { get; set; }
    }
}
