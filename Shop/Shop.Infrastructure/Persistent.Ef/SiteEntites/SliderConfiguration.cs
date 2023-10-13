using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.SiteEntites;

namespace Shop.Infrastructure.Persistent.Ef.SiteEntites
{
    internal class SliderConfiguration : IEntityTypeConfiguration<Slider>
    {
        public void Configure(EntityTypeBuilder<Slider> builder)
        {
            builder.Property(b => b.ImageName)
                .HasMaxLength(120).IsRequired();

            builder.Property(b => b.Title)
                .HasMaxLength(120);

            builder.Property(b => b.Link)
                .HasMaxLength(500);
        }
    }
}
