

using Banking.Domain;

namespace Banking.UnitTests;

public class MakingWithdrawals
{

    [Fact]
    public void MakingAWithdrawalReducesBalance()
    {
        // Given
        var account = new BankAccount();
        var openingBalance = account.GetBalance();
        decimal amountToWithdraw = 100M;
        // When
        account.Withdraw(amountToWithdraw);
        // Then
        Assert.Equal(openingBalance - 100M, account.GetBalance());
    }
}
