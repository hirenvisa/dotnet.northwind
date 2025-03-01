using Microsoft.EntityFrameworkCore;
using Northwind.Domain.Entities;

namespace Northwind.Application.Common.Interfaces;

public interface INorthwindDbContext
{
    DbSet<Customer> Customers { get; set; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
