using System.Reflection;
using System.Text;
using Carter;
using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using ShopyApp;
using ShopyApp.Common.Mapping;
using ShopyApp.Database;
using ShopyApp.Features.Carts;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddAuthFeatures(builder.Configuration)
        .AddProductsFeatures()
        .AddCartFeatures();

    builder.Services.AddDbContext<AppDbContext>();
    builder.Services.AddDbContext<MySqlDbContext>();
    builder.Services.AddCarter();
    builder.Services.AddMapping();
    builder.Services.AddProblemDetails();
    builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapCarter();
    app.Run();
}
