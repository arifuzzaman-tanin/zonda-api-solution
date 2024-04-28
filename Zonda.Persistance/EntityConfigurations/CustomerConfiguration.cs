using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zonda.Application.Entities;

namespace Zonda.Persistance.EntityConfigurations
{
    public class CustomerConfiguration : BaseEntityConfiguration<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder.Property(t => t.Name)
                .HasMaxLength(450)
                .IsRequired();
            entityTypeBuilder.Property(t => t.Contact)
                .HasMaxLength(15)
                .IsRequired();
            entityTypeBuilder.Property(t => t.Address)
                .HasMaxLength(450)
                .IsRequired();
        }
    }
}
