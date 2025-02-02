using Application.Customers.Commands.CreateCustomer;
using Application.UnitTest.Common;
using MediatR;
using Moq;
using Persistence;
using NorthwindDbContextFactory = Application.UnitTest.Common.NorthwindDbContextFactory;

namespace Application.UnitTest.Customers.Command.CreateCustomer;

public class CreateCustomerCommandTest: CommandTestBase
{
    [Fact]
    public void Handle_ValidRequest_ShouldRaiseCustomerCreatedNotification()
    {
        //arrange 
        var mediatrMock = new Mock<IMediator>();
        var sut = new CreateCustomerCommand.Handler(_context, mediatrMock.Object);
        var newCustomerId = "MOQ01";

        // act 
        var result = sut.Handle(new CreateCustomerCommand { CustomerId = newCustomerId }, CancellationToken.None);
        
        // assert
        mediatrMock.Verify(m => m.Publish(It.Is<CustomerCreated>(cc => cc.CustomerId == newCustomerId), It.IsAny<CancellationToken>()), Times.Once);
    }
    
}