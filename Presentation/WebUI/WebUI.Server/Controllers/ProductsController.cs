using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Products.Queries.GetProductsList;

namespace WebUI.Server.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class ProductsController : BaseController
    {
        public async Task<ActionResult<ProductsListVm>> GetAll()
        {
            var vm = await Mediator.Send(new GetProductsListQuery());
            return Ok(vm);
        }
    }
}
