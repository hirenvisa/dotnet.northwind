using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Persistence;

public abstract 
    class DesignTimeDbContextFactoryBase<TContext> : IDesignTimeDbContextFactory<TContext>
    where TContext: DbContext
{
    private readonly string _connectionStringName;
    private readonly string _aspnetcoreEnvironment;
    protected DesignTimeDbContextFactoryBase(string connectionStringName)
    {
        this._connectionStringName = connectionStringName ?? throw new ArgumentException(nameof(connectionStringName));
        this._aspnetcoreEnvironment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development";
    }
    public TContext CreateDbContext(string[] args)
    {
        var basePath = Directory.GetCurrentDirectory() + string.Format("{0}..{0}WebUI", Path.DirectorySeparatorChar);
        return Create(basePath, _aspnetcoreEnvironment);
    }

    protected abstract TContext CreateNewInstance(DbContextOptions<TContext> context);
    private TContext Create(string basePath, string environmentName)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(basePath)
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.local.json", optional: true)
            .AddJsonFile($"appsettings.{environmentName}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();


        string? connectionString = !string.IsNullOrWhiteSpace(_connectionStringName)
            ? configuration.GetConnectionString(_connectionStringName)
            : throw new ArgumentNullException(nameof(_connectionStringName), "connection string name is null or empty.");

        if (string.IsNullOrWhiteSpace(connectionString))
            throw new InvalidOperationException($"connection string '{_connectionStringName}' is not found.");
        
        return Create(connectionString);
    }

    private TContext Create(string? connectionString)
    {
        var optionBuilder = new DbContextOptionsBuilder<TContext>();
        optionBuilder.UseSqlServer(connectionString);
        return CreateNewInstance(optionBuilder.Options);
    }
    
}