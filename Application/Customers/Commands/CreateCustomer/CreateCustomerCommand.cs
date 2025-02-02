using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Commands.CreateCustomer;

public class CreateCustomerCommand: IRequest<Unit>
{
    public string CustomerId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string Company { get; set; }
    public string ContactName { get; set; }
    public string ContactTitle { get; set; }
    public string Country { get; set; }
    public string Fax { get; set; }
    public string Phone { get; set; }
    public string PostalCode { get; set; }
    public string Region { get; set; }

    public class Handler : IRequestHandler<CreateCustomerCommand, Unit>
    {
        private readonly INorthwindDbContext _dbContext;
        private readonly IMediator _mediator;

        public Handler(INorthwindDbContext dbContext, IMediator mediator)
        {
            _dbContext = dbContext;
            _mediator = mediator;
        }

        public async Task<Unit> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = new Customer() { CustomerId = request.CustomerId};
            _dbContext.Customers.Add(customer);
            await _dbContext.SaveChangesAsync(cancellationToken);
            
            await _mediator.Publish(new CustomerCreated { CustomerId = request.CustomerId }, cancellationToken);
            
            return Unit.Value;
        }
    }
}