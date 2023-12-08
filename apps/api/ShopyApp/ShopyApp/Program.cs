using ShopyApp.Application;
using ShopyApp.Application.Services.Authentication;
using ShopyApp.Endpoints;
using ShopyApp.Infrastructure;
using ShopyApp.Models;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication();
    builder.Services.AddInfrastructure();
    builder.Services.AddDbContext<AppDbContext>();
}


var app = builder.Build();
{
    app.MapAuthEndpoints();
    app.MapProductEndpoints();

    app.Run();
}