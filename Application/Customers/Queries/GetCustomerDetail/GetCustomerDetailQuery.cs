using MediatR;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Application.Customers.Queries.GetCustomerDetail;

public class GetCustomerDetailQuery : IRequest<CustomerDetailVm>
{
    public string Id { get; set; }
}