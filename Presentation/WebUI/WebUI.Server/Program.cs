using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Northwind.Application;
using Northwind.Application.System.Commands.SeedSampleData;
using Northwind.Persistence;
using WebUI.Server.Dependencies;

var builder = WebApplication.CreateBuilder(args);

const string ALLOW_DEVELOPMENT_CORS_ORIGINS_POLICY = "AllowDevelopmentSpecificOrigins";

var configuration = builder.Configuration;

// Add services to the container.
builder.Services.AddApplication();
builder.Services.AddPersistence(configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddSwaggerDocument();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
});

builder.Services.AddControllers();
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
});

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}


app.UseDefaultFiles();
app.MapStaticAssets();

app.UseHttpsRedirection();
app.UseAuthorization();

app.UseOpenApi();

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.MapControllers();
app.UseRouting();
app.RegisteredServicesPage(builder.Services);
app.MapFallbackToFile("/index.html");

app.UseCors("AllowAll");


using (var scope = app.Services.CreateScope())
{
    var provider = scope.ServiceProvider;
    try
    {
        var northwindDb = provider.GetRequiredService<NorthwindDbContext>();
        northwindDb.Database.Migrate();

        var mediator = provider.GetRequiredService<IMediator>();
        await mediator.Send(new SeedSampleDataCommand(), CancellationToken.None);

    }catch(Exception ex)
    {
        throw;
    }

}


app.Run();
