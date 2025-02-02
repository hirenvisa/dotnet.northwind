using Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("NorthwindDatabase");
        if (string.IsNullOrEmpty(connectionString))
        {
            throw new InvalidOperationException("Connection string 'NorthwindDatabase' not found.");
        }

        services.AddDbContext<NorthwindDbContext>(options => options.UseSqlServer(connectionString));
        services.AddScoped<INorthwindDbContext>(provider => provider.GetService<NorthwindDbContext>() ?? throw new InvalidOperationException(nameof(provider)));
        return services;
    }
}