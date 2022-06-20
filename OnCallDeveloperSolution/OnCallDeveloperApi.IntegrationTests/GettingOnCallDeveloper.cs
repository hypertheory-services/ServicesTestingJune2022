
namespace OnCallDeveloperApi.IntegrationTests;

public class GettingOnCallDeveloper : IClassFixture<BaseFixture>
{

    private readonly IAlbaHost _host;

    public GettingOnCallDeveloper(BaseFixture fixture)
    {
        _host = fixture.AlbaHost;
    }

    [Fact]
    public async Task GettingTheOncallDeveloperAsync()
    {
        var result = await _host.Scenario(api =>
        {
            // first I want to do a get request to the resource
            api.Get.Url("/"); // what host? what port? who cares!
            api.StatusCodeShouldBeOk();
            // I want to check the status code.
        });


    }
}
