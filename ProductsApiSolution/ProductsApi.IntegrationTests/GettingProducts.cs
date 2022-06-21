

using Alba;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ProductsApi.Adapters;
using ProductsApi.Domain;

namespace ProductsApi.IntegrationTests;

public class GettingProducts : IClassFixture<GetProductsFixture>
{

    private readonly IAlbaHost _host;
    public GettingProducts(GetProductsFixture fixture)
    {
        _host = fixture.AlbaHost;
    }

    [Fact]
    public async Task CanGetProducts()
    {
        var response = await _host.Scenario(api =>
        {
            api.Get.Url("/products");
            api.StatusCodeShouldBeOk();
        });

    }



}


public class GetProductsFixture : FixtureBase
{
    public override void ConfigureServices(IServiceCollection services)
    {
        var productsToReturn = new List<Product>
        {
            new Product { Id = "1", Description="Beer", Price=5.99M},
            new Product { Id = "2", Description="Good Beer", Price =12.999M}
        }.AsQueryable();
        var stubbedProductsCatalog = new Mock<IProductAdapter>();
        stubbedProductsCatalog.Setup(p => p.GetProductsAsync()).ReturnsAsync(productsToReturn);

        services.AddSingleton<IProductAdapter>(_ => stubbedProductsCatalog.Object);
    }
}