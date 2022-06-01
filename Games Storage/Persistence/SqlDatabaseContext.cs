using Games_Storage.Services.SqlService.ApplicationDbContext.FluentApiConfig;
using Microsoft.EntityFrameworkCore;
using Games_Storage.Core.Models;
using Games_Storage.Persistence.EntityConfig;

namespace Games_Storage.Persistence
{
    public class SqlDatabaseContext : DbContext
    {
        public SqlDatabaseContext(DbContextOptions<SqlDatabaseContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new GameEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new StudioEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new GenreEntityTypeConfig());
            modelBuilder.ApplyConfiguration(new GamesGenresEntityTypeConfig());
        }

        public DbSet<Game> Games { get; set; } = null!;
        public DbSet<Studio> Studios { get; set; } = null!;
        public DbSet<Genre> Genres { get; set; } = null!;
        public DbSet<GamesGenres> GamesGenres { get; set; } = null!;
    }
}
