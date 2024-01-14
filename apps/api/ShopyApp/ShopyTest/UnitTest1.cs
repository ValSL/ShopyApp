using Microsoft.AspNetCore.Mvc.Testing;
using ShopyApp.Features.Products.Models;
using ShopyApp.Features.Products.Repositories;

namespace ShopyTest
{
    public class UnitTest1 : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly WebApplicationFactory<Program> _factory;

        public UnitTest1(WebApplicationFactory<Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Test1()
        {
            var client = _factory.CreateClient();

            var response = await client.GetAsync("http://localhost:5228/api/products/1/6"); 

            response.EnsureSuccessStatusCode();
        }
    }
}