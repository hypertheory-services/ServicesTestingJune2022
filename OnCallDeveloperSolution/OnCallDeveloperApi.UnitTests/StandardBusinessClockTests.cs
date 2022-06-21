

using OnCallDeveloperApi.Domain;

namespace OnCallDeveloperApi.UnitTests;

public class StandardBusinessClockTests
{
    [Fact]
    public void DuringBusinessHoursClockReturnsTrue()
    {
        IProvideTheBusinessClock clock = new StandardBusinessClock();

        Assert.True(clock.IsBusinessHours());
    }

    [Fact]
    public void AfterBusinessHoursClockReturnsFalse()
    {
        IProvideTheBusinessClock clock = new StandardBusinessClock();

        Assert.False(clock.IsBusinessHours());
    }
}
