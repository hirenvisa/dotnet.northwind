using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Queries.GetCustomersList;

public class GetCustomersListQueryHandler: IRequestHandler<GetCustomersListQuery, CustomersListVm>
{
    private readonly INorthwindDbContext _dbContext;
    private readonly IMapper _mapper;
    
    public GetCustomersListQueryHandler(INorthwindDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }
    
    public async Task<CustomersListVm> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
    {
        var customers = await _dbContext.Customers
            .ProjectTo<CustomerLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync();

        var vm = new CustomersListVm() { Customers = customers };
        return vm;
    }
}