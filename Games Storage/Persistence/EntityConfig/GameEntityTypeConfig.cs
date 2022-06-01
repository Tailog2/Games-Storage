using Games_Storage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Games_Storage.Services.SqlService.ApplicationDbContext.FluentApiConfig
{
    public class GameEntityTypeConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
           
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Name).HasMaxLength(50);
            builder
                .HasOne(g => g.Studio)
                .WithMany(s => s.Games)
                .HasForeignKey(g => g.StudioId)
                .OnDelete(DeleteBehavior.Restrict)
                .IsRequired();

            builder.Navigation(g => g.GamesGenres).AutoInclude();
            builder.Navigation(g => g.Studio).AutoInclude();
        }
    }
}
