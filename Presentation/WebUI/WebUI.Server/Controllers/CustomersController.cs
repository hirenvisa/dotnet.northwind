using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Customers.Queries.GetCustomersList;

namespace WebUI.Server.Controllers;


[ApiController]
[Route("[controller]")]
public class CustomersController : BaseController
{
    [HttpGet]
    public async Task<ActionResult<CustomersListVm>> GetAll()
    {
        var vm = await Mediator.Send(new GetCustomersListQuery());
        return Ok(vm);
    }
}
