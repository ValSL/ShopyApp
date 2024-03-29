﻿using ShopyApp.Features.Products.Models;

namespace ShopyApp.Features.Products.Repositories;

public interface IProductRepository
{
    IQueryable<Product> GetProducts();
    Product? GetProductById(int id);
    Task CreateProduct(Product product);
    List<Product>? GetProductsByPage(int pageNumber, int pageSize, string query);
}
