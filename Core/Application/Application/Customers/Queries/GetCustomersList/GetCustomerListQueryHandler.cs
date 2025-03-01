
using AutoMapper.QueryableExtensions;
using MediatR;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Northwind.Application.Common.Interfaces;

namespace Northwind.Application.Customers.Queries.GetCustomersList;

public class GetCustomerListQueryHandler : IRequestHandler<GetCustomersListQuery, CustomersListVm>
{
    private readonly IMapper _mapper;
    private readonly INorthwindDbContext _context;

    public GetCustomerListQueryHandler(INorthwindDbContext context, IMapper mapper)
    {
        _mapper = mapper;
        _context = context;
    }

    public async Task<CustomersListVm> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
    {
        var customers = await _context.Customers
            .ProjectTo<CustomerLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        var vm = new CustomersListVm
        {
            Customers = customers
        };


        return vm;
    }
}
