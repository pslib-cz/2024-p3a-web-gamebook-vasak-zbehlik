using Microsoft.EntityFrameworkCore;
using skibidi_gamebook.Server.Models;

namespace skibidi_gamebook.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Connection> Connections { get; set; }
        public DbSet<Character> Characters { get; set; } = default!;


      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           modelBuilder.Entity<Room>() // connections v roomu
               .HasMany(l => l.Connections) 
               .WithOne(b => b.From)
               .HasForeignKey(b => b.FromId);

            modelBuilder.Entity<Room>() //jaka connection vede do roomu
                 .HasOne(l => l.Connection)
                 .WithOne(b => b.To)
                 .HasForeignKey<Connection>(b => b.ToId);

            modelBuilder.Entity<Room>() // itemy v roomu
                .HasMany(l => l.Items)
                .WithOne(b => b.Rooms)
                .HasForeignKey(b => b.RoomId);

            modelBuilder.Entity<Connection>()
                .HasOne(l => l.Requierement)
                .WithOne(b => b.Connection)
                .HasForeignKey<Item>(b => b.ItemId);

            modelBuilder.Entity<Character>()
                .HasOne(l => l.where)
                .WithOne(b => b.Character)
                .HasForeignKey<Room>(b => b.RoomId);
        }
   }
}
