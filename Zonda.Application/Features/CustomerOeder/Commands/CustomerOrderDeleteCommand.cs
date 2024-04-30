using MediatR;
using Microsoft.Extensions.Logging;
using Zonda.Application.Common.Interfaces;
using Zonda.Application.Common.Response;

namespace Zonda.Application.Features.CustomerOeder.Commands
{
    public class CustomerOrderDeleteCommand : IRequest<CustomResponse<bool>>
    {
        public Guid Id { get; set; }

        public class CustomerOrderDeleteCommandHandler : IRequestHandler<CustomerOrderDeleteCommand, CustomResponse<bool>>
        {
            private readonly ILogger<CustomerOrderDeleteCommandHandler> _logger;
            private readonly IUnitOfWork _unitOfWork;

            public CustomerOrderDeleteCommandHandler(IUnitOfWork unitOfWork, ILogger<CustomerOrderDeleteCommandHandler> logger)
            {
                _unitOfWork = unitOfWork;
                _logger = logger;
            }

            public async Task<CustomResponse<bool>> Handle(CustomerOrderDeleteCommand request, CancellationToken cancellationToken)
            {
                CustomResponse<bool> response = new CustomResponse<bool>();

                try
                {
                    var customerOrder = await _unitOfWork.CustomerOrderRepository.GetSingleAsync(x => x.Id == request.Id && !x.IsDeleted);

                    if (customerOrder != null)
                    {
                        customerOrder.IsDeleted = true;
                        customerOrder.DeletedOn = DateTime.UtcNow;
                        _unitOfWork.CustomerOrderRepository.Update(customerOrder);
                        await _unitOfWork.CommitAsync();

                        response.Data = true;
                        response.IsSucceed = true;
                        response.Message = CustomerOrderMessages.SuccessfullyDeletedOrder;
                    }
                    else
                    {
                        response.Message = CustomerOrderMessages.FailedToDeleteOrder;
                    }
                }
                catch (Exception ex)
                {
                    response.Data = false;
                    response.IsSucceed = false;
                    response.Message = CustomerOrderMessages.FailedToDeleteOrder;

                    _logger.LogError(ex, "Exception occured in CustomerOrderDeleteCommandHandler()", ex.Message);
                }

                return response;
            }
        }
    }
}

