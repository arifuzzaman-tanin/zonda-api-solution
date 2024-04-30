using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Zonda.Application.Common.Bases;
using Zonda.Application.Common.Interfaces;
using Zonda.Application.Common.Mappings;
using Zonda.Application.Features.CustomerOeder.Queries.DTO;

namespace Zonda.Application.Features.CustomerOeder.Queries
{
    public class CustomerOrderQuery : BasePaginationQuery<CustomerOrderQueryDTO>
    {
        public Guid CustomerId { get; set; }

        public class CustomerOrderQueryHandler : IRequestHandler<CustomerOrderQuery, PaginatedList<CustomerOrderQueryDTO>>
        {
            private readonly ILogger<CustomerOrderQueryHandler> _logger;
            private readonly IMapper _mapper;
            private readonly IUnitOfWork _unitOfWork;

            public CustomerOrderQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ILogger<CustomerOrderQueryHandler> logger)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
                _logger = logger;
            }

            public async Task<PaginatedList<CustomerOrderQueryDTO>> Handle(CustomerOrderQuery request, CancellationToken cancellationToken)
            {
                PaginatedList<CustomerOrderQueryDTO> result = null;
                try
                {
                    var customerOrders = await _unitOfWork.CustomerOrderRepository.FilterAsync(x => !x.IsDeleted && x.CustomerId == request.CustomerId, source => source.Include(x => x.Customer).Include(x => x.Product));
                    
                    if (customerOrders.Any() 
                        && !string.IsNullOrEmpty(request.SortDirection)
                        && !string.IsNullOrEmpty(request.SortColumn))
                    {
                        if (request.SortColumn.Trim().ToUpper() == "PRODUCTID")
                        {
                            if (request.SortDirection.Trim().ToUpper() == "DESC")
                            {
                                customerOrders = customerOrders.OrderByDescending(x => x.Product.Code);
                            }
                        }
                    }
                    
                    IQueryable<CustomerOrderQueryDTO> finalQuery = customerOrders.Select(x => new CustomerOrderQueryDTO
                    {
                        Id = x.Id,
                        CustomerId = x.CustomerId,
                        Customer = x.Customer,
                        ProductId = x.ProductId,
                        Product = x.Product
                    });

                    result = await finalQuery.PaginatedListAsync(request.PageIndex, request.PageSize);
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Exception occured in CustomerOrderQueryHandler()", ex.Message);
                }

                return result;
            }
        }
    }
}
