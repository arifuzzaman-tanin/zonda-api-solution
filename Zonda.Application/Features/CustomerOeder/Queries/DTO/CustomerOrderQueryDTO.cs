using Zonda.Application.Common.Mappings;

namespace Zonda.Application.Features.CustomerOeder.Queries.DTO
{
    public class CustomerOrderQueryDTO : IMapFrom<Entities.CustomerOrder>
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public Entities.Customer Customer { get; set; }
        public Guid ProductId { get; set; }
        public Entities.Product Product { get; set; }
    }
}
