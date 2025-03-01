namespace WebUI.Server.Dependencies;

public static class DependencyInjection
{
    public static IServiceCollection AddNSwag(this IServiceCollection services)
    {
        services.AddOpenApiDocument(configure =>
                configure.Title = "Northwind Traders API"
           );

        return services;
    }
}
