using Microsoft.AspNetCore.Mvc;
using ShopyApp;
using ShopyApp.Application;
using ShopyApp.Controllers;
using ShopyApp.Infrastructure;
using ShopyApp.Models;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddApplication()
                    .AddInfrastructure(builder.Configuration)
                    .AddPresentation();
    builder.Services.AddDbContext<AppDbContext>();
}


var app = builder.Build();
{
    //app.UseExceptionHandler("/error");
    app.MapControllers();

    app.Run();
}
