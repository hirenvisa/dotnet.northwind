using Application.Common.Exceptions;
using Application.Common.Interfaces;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Customers.Commands.UpdateCustomer;

public class UpdateCustomerCommand : IRequest<Unit>
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

    public class Handler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly INorthwindDbContext _dbContext;
        private readonly IMapper _mapper;

        public Handler(INorthwindDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Customers
                .SingleOrDefaultAsync(c => c.CustomerId == request.CustomerId, cancellationToken);
            
            if (entity == null) 
                throw new NotFoundException(nameof(Customer), request.CustomerId);

            entity.Address = request.Address;
            entity.City = request.City;
            entity.CompanyName = request.Company;
            entity.ContactName = request.ContactName;
            entity.ContactTitle = request.ContactTitle;
            entity.Country = request.Country;
            entity.Fax = request.Fax;
            entity.Phone = request.Phone;
            entity.PostalCode = request.PostalCode;
            
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}