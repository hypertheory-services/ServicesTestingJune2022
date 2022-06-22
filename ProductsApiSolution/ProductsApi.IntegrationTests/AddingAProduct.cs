

using Alba;

namespace ProductsApi.IntegrationTests;

public class AddingAProduct : IClassFixture<AddingAProductFixture>
{

    private readonly IAlbaHost _host;
    public AddingAProduct(AddingAProductFixture fixture)
    {

        _host = fixture.AlbaHost;
    }

    [Fact]
    public async Task CanAddAProduct()
    {
        var response = await _host.Scenario(api =>
        {
            var requestData = new CreateProductModel("beer", 12.99M);
            api.Post.Json(requestData).ToUrl("/products");
            api.StatusCodeShouldBe(200); // lie!
        });
    }

    [Fact]
    public async Task ValidationIsHookedUp()
    {
        var response = await _host.Scenario(api =>
        {
            var gratiutiouslyBadRequest = new CreateProductModel(null, null);
            api.Post.Json(gratiutiouslyBadRequest).ToUrl("/products");
            api.StatusCodeShouldBe(400); // lie!
        });
    }
}


public class AddingAProductFixture: FixtureBase { }

public record CreateProductModel(string? description, decimal? price);