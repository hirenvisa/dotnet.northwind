using MediatR;

namespace Application.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommand : IRequest<Unit>
{
    public string Id { get; set; }
}