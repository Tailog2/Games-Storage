using Games_Storage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Games_Storage.Persistence.EntityConfig
{
    public class GamesGenresEntityTypeConfig : IEntityTypeConfiguration<GamesGenres>
    {
        public void Configure(EntityTypeBuilder<GamesGenres> builder)
        {
            builder
                .HasKey(gg => new { gg.GamesId, gg.GenresId });
            builder
                .HasOne(gg => gg.Game)
                .WithMany(g => g.GamesGenres)
                .HasForeignKey(gg => gg.GamesId)
                .OnDelete(DeleteBehavior.Cascade);
            builder
                .HasOne(gg => gg.Genre)
                .WithMany(g => g.GamesGenres)
                .HasForeignKey(gg => gg.GenresId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(g => g.Genre).AutoInclude();
        }
    }
}
