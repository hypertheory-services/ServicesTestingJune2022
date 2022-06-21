namespace OnCallDeveloperApi.Domain;

public class StandardBusinessClock : IProvideTheBusinessClock
{
    public bool IsBusinessHours()
    {
        return true;
    }
}
