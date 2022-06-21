using OnCallDeveloperApi.Adapters;

namespace OnCallDeveloperApi.Domain;

public class StandardBusinessClock : IProvideTheBusinessClock
{
    private readonly ISystemTime _systemTime;

    public StandardBusinessClock(ISystemTime systemTime)
    {
        _systemTime = systemTime;
    }

    public bool IsBusinessHours()
    {
        var now = _systemTime.GetCurrent();
        if (IsTheWeekend(now))
        {
            return false;
        }
        return AfterStart(now) && BeforeClose(now);
    }

    private static bool AfterStart(DateTime now)
    {
        return now.Hour >= 8 && now.Minute >= 30;
    }

    private static bool BeforeClose(DateTime now)
    {
        return now.Hour >= 17 && now.Minute < 1;
    }
    private static bool IsTheWeekend(DateTime now)
    {
        return now.DayOfWeek == DayOfWeek.Sunday || now.DayOfWeek == DayOfWeek.Saturday;
    }
}
