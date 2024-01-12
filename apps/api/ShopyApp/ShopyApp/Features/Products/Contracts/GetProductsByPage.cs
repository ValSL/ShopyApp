using Microsoft.AspNetCore.Mvc;

namespace ShopyApp.Features.Products.Contracts;

public record GetProductsByPageRequest(int PageNumber, int PageSize, string? Query, string? From, string? To);