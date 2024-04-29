using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Zonda.Application.Common.Interfaces;
using Zonda.Application.Common.Response;
using Zonda.Application.Features.Customer.Queries.DTO;

namespace Zonda.Application.Features.Customer.Queries
{
    public class GetCustomerQuery : IRequest<CustomResponse<List<GetCustomerQueryDTO>>>
    {
        public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, CustomResponse<List<GetCustomerQueryDTO>>>
        {
            private readonly ILogger<GetCustomerQueryHandler> _logger;
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public GetCustomerQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetCustomerQueryHandler> logger)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<CustomResponse<List<GetCustomerQueryDTO>>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
            {
                CustomResponse<List<GetCustomerQueryDTO>> response = new CustomResponse<List<GetCustomerQueryDTO>>();

                try
                {
                    var customers = await _unitOfWork.CustomerRepository.FilterAsync(x => !x.IsDeleted);

                    response.Data = _mapper.Map<List<Entities.Customer>, List<GetCustomerQueryDTO>>(customers.ToList());
                    response.IsSucceed = true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception occured in GetCustomerQueryHandler()", ex.Message);
                }

                return response;
            }
        }
    }
}
