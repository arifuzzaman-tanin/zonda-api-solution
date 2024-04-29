using Zonda.Application.Common.Mappings;

namespace Zonda.Application.Features.Product.Queries.DTO
{
    public class GetProductQueryDTO : IMapFrom<Entities.Product>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Code { get; set; }
        public decimal Price { get; set; }
    }
}
