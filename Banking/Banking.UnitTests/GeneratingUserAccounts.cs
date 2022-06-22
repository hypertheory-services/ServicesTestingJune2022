
using Moq.Protected;

namespace Banking.UnitTests;

public class GeneratingUserAccounts
{

    [Theory]
    [InlineData("Bob", "Smith", 38, "bob-smith-18")]
    [InlineData("Jill", "Jones", 38, "jill-jones-18")]
    public void CanGenerateUserAccounts(string first, string last, int age, string expected)
    {
        var generator = new ScaffoldedUserAccountGenerator();

        var result = generator.CreateUserAccount(first, last, age);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("Bob", "Smith", 38, "bob-smith-0")]
    [InlineData("Jill", "Jones", 38, "jill-jones-0")]
    public void CanGenerateUserAccountsWithMock(string first, string last, int age, string expected)
    {
        var generator = new Mock<UserAccountGenerator>();
        generator.Protected().Setup<int>("GetRandomKey", It.IsAny<int>()).Returns(0);
        //var generator = new UserAccountGenerator();

        var result = generator.Object.CreateUserAccount(first, last, age);

        Assert.Equal(expected, result);
    }

}

public class ScaffoldedUserAccountGenerator : UserAccountGenerator
{
    protected override int GetRandomKey(int age)
    {
        return 18;
    }
}