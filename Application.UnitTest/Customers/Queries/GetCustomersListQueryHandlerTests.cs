using Application.Common.Interfaces;
using Application.Common.Mapper;
using Application.Customers.Queries.GetCustomersList;
using Application.UnitTest.Common;
using AutoMapper;
using Shouldly;

namespace Application.UnitTest.Customers.Queries;

[Collection("QueryCollection")]
public class GetCustomersListQueryHandlerTests
{
    private readonly INorthwindDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomersListQueryHandlerTests(QueryTestFixture context)
    {
        this._context = context.Context;
        this._mapper = context.Mapper;
    }

    [Fact]
    public async Task GetCustomersTest()
    {
        var sut = new GetCustomersListQueryHandler(_context, _mapper);
        var result = await sut.Handle(new GetCustomersListQuery(), CancellationToken.None);
        result.ShouldBeOfType<CustomersListVm>();
        result.Customers.Count.ShouldBe(3);
    }
    

}