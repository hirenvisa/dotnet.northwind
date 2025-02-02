using Application.Common.Exceptions;
using Application.Customers.Commands.DeleteCustomer;
using Application.UnitTest.Common;

namespace Application.UnitTest.Customers.Command.DeleteCustomre;

public class DeleteCustomerCommandTest: CommandTestBase
{
    private readonly DeleteCustomerCommandHandler _sut;

    public DeleteCustomerCommandTest() : base()
    {
        _sut = new DeleteCustomerCommandHandler(_context);
    }

    [Fact]
    public async Task Handle_GivenInvalidId_ThrowsNotFoundException()
    {
        var customerID = "INVAL";
        var command = new DeleteCustomerCommand { Id = customerID };
        await Assert.ThrowsAsync<NotFoundException>(() => _sut.Handle(command, CancellationToken.None));
    }

    [Fact]
    public async Task Handle_GivenId_DeleteCustomer()
    {
        var validId = "JASON";
        var command = new DeleteCustomerCommand { Id = validId };
        _sut.Handle(command, CancellationToken.None);
        var customer = await _context.Customers.FindAsync(validId);
        Assert.Null(customer);
    }
}