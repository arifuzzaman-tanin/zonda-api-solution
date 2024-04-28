using Zonda.Application.Entities.Base;

namespace Zonda.Application.Entities
{
    public class Customer : BaseEntity
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Address { get; set; }
    }
}
