using Zonda.Application.Common.Mappings;

namespace Zonda.Application.Features.Customer.Queries.DTO
{
    public class GetCustomerQueryDTO : IMapFrom<Entities.Customer>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
    }
}
