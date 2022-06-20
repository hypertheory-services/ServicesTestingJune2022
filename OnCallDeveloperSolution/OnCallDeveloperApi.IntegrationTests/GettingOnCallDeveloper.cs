
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


        var returnedDeveloper = result.ReadAsJson<DeveloperResponse>();

        var expectedResponse = new DeveloperResponse
        {
            name = "Sue Jones",
            email = "sue@aol.com",
            phone = "555-1212"
        };
        Assert.Equal(expectedResponse, returnedDeveloper);
    }
}


public record DeveloperResponse
{
    public string name { get; set; }
    public string email { get; set; }
    public string phone { get; set; }
}

