using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Customers.Commands.DeleteCustomer;

public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
{
    private readonly INorthwindDbContext _dbContext;

    public DeleteCustomerCommandHandler(INorthwindDbContext dbContext) =>
        _dbContext = dbContext;

    public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
    {
        var customer = await _dbContext.Customers.FindAsync(new object[] { request.Id }, cancellationToken);
        if (customer == null)
        {
            throw new NotFoundException( nameof(Customer), request.Id);
        }

        _dbContext.Customers.Remove(customer);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}