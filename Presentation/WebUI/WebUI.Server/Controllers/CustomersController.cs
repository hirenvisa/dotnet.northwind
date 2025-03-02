using Microsoft.AspNetCore.Mvc;
using Northwind.Application.Customers.Queries.GetCustomerDetail;
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

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CustomerDetailVm>> Get(string id)
    {
        var vm = await Mediator.Send(new GetCustomerDetailQuery() {  Id = id});
        return Ok(vm);
    }
}
