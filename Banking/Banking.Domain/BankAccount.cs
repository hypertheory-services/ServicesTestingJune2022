namespace Banking.Domain;

public class BankAccount
{
    private decimal _currentBalance = 5000M;
    private readonly ICalculateBonuses _bonusCalculator;

    public BankAccount(ICalculateBonuses bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }

    public decimal GetBalance()
    {
        return _currentBalance;
    }

    public void Withdraw(decimal amountToWithdraw)
    {
        if (amountToWithdraw <= _currentBalance)
        {
            _currentBalance = _currentBalance - amountToWithdraw;
         //   _currentBalance -= amountToWithdraw;
        } else
        {
            throw new OverdraftException();
        }
    }

    public void Deposit(decimal amountToDeposit)
    {
        // WTCYWYH
        decimal bonus = _bonusCalculator.GetBonusForDeposit(this, amountToDeposit);
        _currentBalance += amountToDeposit + bonus;
    }
}