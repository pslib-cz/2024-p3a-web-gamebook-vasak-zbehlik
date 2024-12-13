using Microsoft.EntityFrameworkCore;
using skibidi_gamebook.Server.Models;
using Task = skibidi_gamebook.Server.Models.Task;

namespace skibidi_gamebook.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Achivement> Achivements { get; set; }
        public DbSet<Task> Tasks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("YourConnectionStringHere");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Relationships for Connection
            modelBuilder.Entity<Connection>()
                .HasOne(c => c.From)
                .WithMany()
                .HasForeignKey(c => c.FromId);

            modelBuilder.Entity<Connection>()
                .HasOne(c => c.To)
                .WithMany()
                .HasForeignKey(c => c.ToId);

            modelBuilder.Entity<Connection>()
                .HasOne(c => c.Requirements)
                .WithMany()
                .HasForeignKey(c => c.RequirementsId);

            // Relationships for Task
            modelBuilder.Entity<Task>()
                .HasOne(t => t.Requirements)
                .WithMany(a => a.Tasks)
                .HasForeignKey(t => t.RequirementsId);
        }
    }
}
