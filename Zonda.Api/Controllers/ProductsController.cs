using Microsoft.AspNetCore.Mvc;
using Zonda.Application.Features.Product.Queries;

namespace Zonda.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseApiController
    {
        [HttpGet()]
        [Route("GetProducts")]
        public async Task<IActionResult> GetProductQuery()
        {
            return Ok(await Mediator.Send(new GetProductQuery { }));
        }
    }
}
