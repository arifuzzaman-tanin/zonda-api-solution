using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Zonda.Application.Common.Interfaces;
using Zonda.Application.Common.Response;
using Zonda.Application.Features.Product.Queries.DTO;

namespace Zonda.Application.Features.Product.Queries
{
    public class GetProductQuery : IRequest<CustomResponse<List<GetProductQueryDTO>>>
    {
        public class GetProductQueryHandler : IRequestHandler<GetProductQuery, CustomResponse<List<GetProductQueryDTO>>>
        {
            private readonly ILogger<GetProductQueryHandler> _logger;
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public GetProductQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<GetProductQueryHandler> logger)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<CustomResponse<List<GetProductQueryDTO>>> Handle(GetProductQuery request, CancellationToken cancellationToken)
            {
                CustomResponse<List<GetProductQueryDTO>> response = new CustomResponse<List<GetProductQueryDTO>>();

                try
                {
                    var products = await _unitOfWork.ProductRepository.FilterAsync(x => !x.IsDeleted);

                    response.Data = _mapper.Map<List<Entities.Product>, List<GetProductQueryDTO>>(products.ToList());
                    response.IsSucceed = true;
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception occured in GetProductQueryHandler()", ex.Message);
                }

                return response;
            }
        }
    }
}
