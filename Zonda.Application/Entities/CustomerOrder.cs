using Zonda.Application.Entities.Base;

namespace Zonda.Application.Entities
{
    public class CustomerOrder : BaseEntity
    {
        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
