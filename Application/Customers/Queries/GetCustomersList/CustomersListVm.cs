namespace Application.Customers.Queries.GetCustomersList;

public class CustomersListVm
{
    public IList<CustomerLookupDto> Customers { get; set; } = new List<CustomerLookupDto>();
}