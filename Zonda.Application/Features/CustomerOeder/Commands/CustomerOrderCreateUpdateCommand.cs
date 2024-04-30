using MediatR;
using Microsoft.Extensions.Logging;
using Zonda.Application.Common.Interfaces;
using Zonda.Application.Common.Response;
using Zonda.Application.Features.CustomerOeder.Commands.DTO;
using Zonda.Application.Features.CustomerOeder.Queries.DTO;

namespace Zonda.Application.Features.CustomerOeder.Commands
{
    public class CustomerOrderCreateUpdateCommand : IRequest<CustomResponse<bool>>
    {
        public CustomerOrderCreateUpdateDTO CustomerOrder { get; set; }

        public class CustomerOrderCreateUpdateCommandHandler : IRequestHandler<CustomerOrderCreateUpdateCommand, CustomResponse<bool>>
        {
            private readonly ILogger<CustomerOrderCreateUpdateCommandHandler> _logger;
            private readonly IUnitOfWork _unitOfWork;

            public CustomerOrderCreateUpdateCommandHandler(IUnitOfWork unitOfWork, ILogger<CustomerOrderCreateUpdateCommandHandler> logger)
            {
                _unitOfWork = unitOfWork;
                _logger = logger;
            }

            public async Task<CustomResponse<bool>> Handle(CustomerOrderCreateUpdateCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();

                try
                {
                    var customerOrder = new Entities.CustomerOrder();
                    customerOrder.Id = Guid.NewGuid();
                    customerOrder.CustomerId = request.CustomerOrder.CustomerId;
                    customerOrder.ProductId = request.CustomerOrder.ProductId;
                    _unitOfWork.CustomerOrderRepository.Insert(customerOrder);
                    await _unitOfWork.CommitAsync();

                    response.Data = true;
                    response.IsSucceed = true;
                    response.Message = CustomerOrderMessages.SuccessfullyCreatedNewOrder;
                }
                catch (Exception ex)
                {
                    response.Data = false;
                    response.IsSucceed = false;
                    response.Message = CustomerOrderMessages.SuccessfullyCreatedNewOrder;

                    _logger.LogError(ex, "Exception occured in CustomerOrderQueryHandler()", ex.Message);
                }
                
                return response;
            }
        }
    }
}
