using Microsoft.AspNetCore.Mvc;
using Zonda.Application.Features.CustomerOeder.Commands;
using Zonda.Application.Features.CustomerOeder.Queries;

namespace Zonda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerOrdersController : BaseApiController
    {
        [HttpGet()]
        [Route("GetCustomerOrder")]
        public async Task<IActionResult> CustomerOrderQuery([FromQuery] CustomerOrderQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost()]
        [Route("Create")]
        public async Task<IActionResult> CustomerOrderCreateUpdate([FromBody] CustomerOrderCreateUpdateCommand query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}
