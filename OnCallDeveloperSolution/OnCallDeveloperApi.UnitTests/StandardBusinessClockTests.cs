

using Moq;
using OnCallDeveloperApi.Adapters;
using OnCallDeveloperApi.Domain;

namespace OnCallDeveloperApi.UnitTests;

public class StandardBusinessClockTests
{
    [Theory]
    [InlineData(8,30,00)]
    [InlineData(17,00,00)]
    public void DuringBusinessHoursClockReturnsTrue(int hour, int minute, int second)
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(2022, 6, 21, hour, minute, second));
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);

        Assert.True(clock.IsBusinessHours());
    }

    [Theory]
    [InlineData(8,29,59)]
    public void AfterBusinessHoursClockReturnsFalse(int hour, int minute, int second)
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(2022, 6, 21, hour, minute, second));
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);

        Assert.False(clock.IsBusinessHours());
    }

    [Theory]
    [InlineData(6,25)]
    public void ClosedOnWeekends(int month, int day)
    {
        var stubbedClock = new Mock<ISystemTime>();
        stubbedClock.Setup(c => c.GetCurrent()).Returns(new DateTime(2022, month, day, 11, 00, 00));
        IProvideTheBusinessClock clock = new StandardBusinessClock(stubbedClock.Object);

        Assert.False(clock.IsBusinessHours());
    }
}
