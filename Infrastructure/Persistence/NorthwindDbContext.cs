using Microsoft.EntityFrameworkCore;
using Northwind.Application.Common.Interfaces;
using Northwind.Domain.Entities;

namespace Northwind.Persistence;

public class NorthwindDbContext : DbContext, INorthwindDbContext
{
    public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options): base(options) { }

    public DbSet<Customer> Customers { get; set; }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        return base.SaveChangesAsync(cancellationToken);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NorthwindDbContext).Assembly);
    }
}
