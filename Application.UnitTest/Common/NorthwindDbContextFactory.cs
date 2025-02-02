using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.UnitTest.Common;

public class NorthwindDbContextFactory
{
    public static NorthwindDbContext Create()
    {
        var options = new DbContextOptionsBuilder<NorthwindDbContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;

        var context = new NorthwindDbContext(options);

        context.Customers.AddRange(new[]
        {
            new Customer { CustomerId = "ADAM"},
            new Customer { CustomerId = "JASON"},
            new Customer { CustomerId = "BREND"}
        });

        context.SaveChangesAsync(CancellationToken.None);
        
        return context;
    }

    public static void Distroy(NorthwindDbContext context)
    {
        context.Database.EnsureDeleted();
    }
}