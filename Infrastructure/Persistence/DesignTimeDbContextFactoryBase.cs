using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Northwind.Persistence;

public abstract class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext>
    where TContext : DbContext
{
    private const string ConnectionStringName = "NorthwindDatabase";
    private const string AspNetCoreEnvironment = "ASPNETCORE_ENVIRONMENT";
    protected abstract TContext CreateNewInstance(DbContextOptions<TContext> options);

    public TContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}WebUI.Server", Path.DirectorySeparatorChar);
        Console.WriteLine($"base path: {basePath}");

        return Create(basePath, Environment.GetEnvironmentVariable(AspNetCoreEnvironment));
    }
    private TContext Create(string basePath, string environmentName)
    {
        var configuration = new ConfigurationBuilder()
               .SetBasePath(basePath)
               .AddJsonFile("appsettings.json")
               .AddJsonFile($"appsettings.Local.json", optional: true)
               .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
               .AddEnvironmentVariables()
               .Build();

        var connectionString = configuration.GetConnectionString(ConnectionStringName);

        return Create(connectionString);
    }

    private TContext Create(string connectionString)
    {
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new ArgumentException($"Connection string '{ConnectionStringName}' is null or empty.", nameof(connectionString));
        }

        Console.WriteLine($"DesignTimeDbContextFactoryBase.Create(string): Connection string: '{connectionString}'.");

        var optionsBuilder = new DbContextOptionsBuilder<TContext>();

        optionsBuilder.UseSqlServer(connectionString);

        return CreateNewInstance(optionsBuilder.Options);
    }
}
