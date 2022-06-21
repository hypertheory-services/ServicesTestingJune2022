

using Alba;

namespace ProductsApi.IntegrationTests;

public class GettingProducts : IClassFixture<FixtureBase>
{

    private readonly IAlbaHost _host;
    public GettingProducts(FixtureBase fixture)
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
