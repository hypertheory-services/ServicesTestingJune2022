
namespace Banking.Domain;

public class UserAccountGenerator
{
    private readonly IGenerateUserAccountSeeds _userAccountSeedGenerator;

    public UserAccountGenerator(IGenerateUserAccountSeeds userAccountSeedGenerator)
    {
        _userAccountSeedGenerator = userAccountSeedGenerator;
    }

    // This is not good for NEW code
    public UserAccountGenerator()
    {
        _userAccountSeedGenerator = new RandomUserAccountSeeder();
    }

    public string CreateUserAccount(string firstName, string lastName, int age)
    {
        // "bob-smith-13"
        int num = GetRandomKey(age);

        return $"{firstName.Trim().ToLower()}-{lastName.Trim().ToLower()}-{num}";
    }

    protected virtual int GetRandomKey(int age)
    {
        return _userAccountSeedGenerator.GetSeedFor(age);
    }
}
