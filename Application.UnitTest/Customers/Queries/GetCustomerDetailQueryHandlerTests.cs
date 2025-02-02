using Application.Common.Interfaces;
using Application.Customers.Queries.GetCustomerDetail;
using Application.UnitTest.Common;
using AutoMapper;
using Shouldly;

namespace Application.UnitTest.Customers.Queries;

[Collection("QueryCollection")]
public class GetCustomerDetailQueryHandlerTests
{
    private readonly INorthwindDbContext _context;
    private readonly IMapper _mapper;

    public GetCustomerDetailQueryHandlerTests(QueryTestFixture fixture)
    {
        this._context = fixture.Context;
        this._mapper = fixture.Mapper;
    }

    [Fact]
    public async Task GetCustomerDetail()
    {
        var sut = new GetCustomerDetailQueryHandler(_context, _mapper);
        var result = await sut.Handle(new GetCustomerDetailQuery { Id = "JASON" }, CancellationToken.None);
        result.ShouldBeOfType<CustomerDetailVm>();
        result.Id.ShouldBe("JASON");
    }
    
    
}