using Microsoft.AspNetCore.Mvc;
using Zonda.Application.Features.Customer.Queries;

namespace Zonda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : BaseApiController
    {
        [HttpGet()]
        [Route("GetCustomers")]
        public async Task<IActionResult> GetCustomerQuery()
        {
            return Ok(await Mediator.Send( new GetCustomerQuery { }));
        }
    }
}
