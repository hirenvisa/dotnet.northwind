using Microsoft.EntityFrameworkCore;

namespace Persistence;

public class NorthwindDbContextFactory(string connectionStringName)
    : DesignTimeDbContextFactoryBase<NorthwindDbContext>(connectionStringName)
{
    protected override NorthwindDbContext CreateNewInstance(DbContextOptions<NorthwindDbContext> options)
    {
        return new NorthwindDbContext(options);
    }
}