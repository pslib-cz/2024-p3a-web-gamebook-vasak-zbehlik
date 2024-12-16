using skibidi_gamebook.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.OpenApi;
using Microsoft.AspNetCore.Http.HttpResults;
using System.ComponentModel.DataAnnotations;
namespace skibidi_gamebook.Server.Models
{
    public class Achivement
    {
        [Key]
        public int AId { get; set; } // PK
        public string? Name { get; set; }
        public string? Description { get; set; }
        public Item Item { get; set; }     //item needed to unlock
      
    }

}