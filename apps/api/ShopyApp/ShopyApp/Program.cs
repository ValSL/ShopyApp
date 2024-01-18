using System.Reflection;
using Carter;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using ShopyApp;
using ShopyApp.Common.Mapping;
using ShopyApp.Database;
using ShopyApp.Features.Carts;
using ShopyApp.Features.Products.Services;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy(name: "ShopySpecificOrigins", policy =>
        {
            policy.WithOrigins("http://localhost:3000", "https://shopy-app-seven.vercel.app")
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowCredentials();
        });
    });

    builder.Services.Configure<CloudinaryOptions>(builder.Configuration.GetSection("CloudinaryOptions"));

    builder.Services
        .AddAuthFeatures(builder.Configuration)
        .AddProductsFeatures()
        .AddCartFeatures();

    builder.Services.AddDbContext<PostgreSqlDbContext>(
        options => options.UseNpgsql("name=ConnectionStrings:PostgreSql"));

    builder.Services.AddDbContext<MySqlDbContext>();
    builder.Services.AddCarter();
    builder.Services.AddMapping();
    builder.Services.AddProblemDetails();
    builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
}

var app = builder.Build();
{
    app.UseExceptionHandler("/error");

    app.UseCors("ShopySpecificOrigins");

    app.UseAuthentication();
    app.UseAuthorization();

    app.MapCarter();
    app.Run();
}

public partial class Program { }