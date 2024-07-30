

namespace Banking.Domain;

public class Account
{
    private decimal _currentBalance = 7000;
    public void Deposit(decimal amountToDeposit)
    {
        _currentBalance += amountToDeposit;
    }

    public decimal GetBalance()
    {
        return _currentBalance;
    }
}