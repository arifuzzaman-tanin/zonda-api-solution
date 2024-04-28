using Zonda.Application.Entities.Base;

namespace Zonda.Application.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Code { get; set; }
        public decimal Price { get; set; }
    }
}
