using ShopyApp.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>();

var app = builder.Build();

app.MapGet("/api/products", (AppDbContext db) =>
{
    return db.Products;
});

app.Run();