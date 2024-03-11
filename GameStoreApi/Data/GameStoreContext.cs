using GameStoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace GameStoreApi.Data
{
    public class GameStoreContext(DbContextOptions<GameStoreContext> options) : DbContext(options)
    {
        public DbSet<Game> Games => Set<Game>();

        public DbSet<Genre> Genres => Set<Genre>();

        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Genre>().HasData([
                new Genre {Id = 1, Name="Fighting"},
                new Genre {Id = 2, Name="Roleplaying"},
                new Genre {Id = 3, Name="Sport"},
                new Genre {Id = 4, Name="Racing"},
                new Genre {Id = 5, Name="Kids & Family"}
            ]);

            base.OnModelCreating(modelBuilder);
        }
    }
}
