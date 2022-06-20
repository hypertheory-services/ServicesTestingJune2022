namespace Banking.Domain;

public class BankAccount
{
    private decimal _currentBalance = 5000M;
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
}