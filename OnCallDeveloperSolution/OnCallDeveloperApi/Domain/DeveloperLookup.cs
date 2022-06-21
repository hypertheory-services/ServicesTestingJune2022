namespace OnCallDeveloperApi.Domain;

public class DeveloperLookup
{
    public OnCallDeveloperResponse GetOnCallDeveloper()
    {
        var response = new OnCallDeveloperResponse
        {
            Name = "Sue Jones",
            Email = "sue@aol.com",
            Phone = "555-1212"
        };
        return response;
    }
}
