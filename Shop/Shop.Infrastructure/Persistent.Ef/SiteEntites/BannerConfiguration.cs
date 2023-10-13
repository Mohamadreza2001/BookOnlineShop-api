using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SiteEntites;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntites
{
    internal class BannerConfiguration : IEntityTypeConfiguration<Banner>
    {
        public void Configure(EntityTypeBuilder<Banner> builder)
        {
            builder.Property(b => b.ImageName)
                .HasMaxLength(120).IsRequired();

            builder.Property(b => b.Link)
                .HasMaxLength(500).IsRequired();
        }
    }
}
