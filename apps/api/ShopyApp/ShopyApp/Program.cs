using System.Reflection;
using Carter;
using FluentValidation;
using ShopyApp.Common.Mapping;
using ShopyApp.Database;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddAuthFeatures(builder.Configuration);
    builder.Services.AddDbContext<AppDbContext>();
    builder.Services.AddCarter();
    builder.Services.AddMapping();
    builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
}


var app = builder.Build();
{
    app.MapCarter();
    app.Run();
}
