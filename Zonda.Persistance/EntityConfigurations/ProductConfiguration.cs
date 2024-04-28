using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zonda.Application.Entities;

namespace Zonda.Persistance.EntityConfigurations
{
    public class ProductConfiguration : BaseEntityConfiguration<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.Name)
                .HasMaxLength(450)
                .IsRequired();
            entityTypeBuilder.Property(t => t.Code)
                .IsRequired();

            entityTypeBuilder.Property(t => t.Price)
                .IsRequired();
        }
    }
}
