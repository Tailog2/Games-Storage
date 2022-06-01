using Games_Storage.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Games_Storage.Services.SqlService.ApplicationDbContext.FluentApiConfig
{
    public class StudioEntityTypeConfig : IEntityTypeConfiguration<Studio>
    {
        public void Configure(EntityTypeBuilder<Studio> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Name).HasMaxLength(50);
        }
    }
}
