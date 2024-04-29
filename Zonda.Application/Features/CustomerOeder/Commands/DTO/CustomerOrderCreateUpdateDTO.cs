namespace Zonda.Application.Features.CustomerOeder.Commands.DTO
{
    public class CustomerOrderCreateUpdateDTO
    {
        public Guid? Id { get; set; }
        public Guid CustomerId { get; set; }
        public Guid ProductId { get; set; }
    }
}
