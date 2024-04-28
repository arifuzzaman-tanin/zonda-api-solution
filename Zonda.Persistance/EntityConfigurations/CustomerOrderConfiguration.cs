using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Zonda.Application.Entities;

namespace Zonda.Persistance.EntityConfigurations
{
    public class CustomerOrderConfiguration : BaseEntityConfiguration<CustomerOrder>
    {
        public override void Configure(EntityTypeBuilder<CustomerOrder> entityTypeBuilder)
        {
            base.Configure(entityTypeBuilder);

            entityTypeBuilder
                .Property(co => co.CustomerId)
                .IsRequired();

            entityTypeBuilder
                .HasOne(co => co.Customer)
                .WithMany()
                .HasForeignKey(co => co.CustomerId)
                .OnDelete(DeleteBehavior.Restrict); // or any other delete behavior as required

            entityTypeBuilder
                .Property(co => co.ProductId)
                .IsRequired();

            entityTypeBuilder
                .HasOne(co => co.Product)
                .WithMany()
                .HasForeignKey(co => co.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // or any other delete behavior as required
        }
    }
}
