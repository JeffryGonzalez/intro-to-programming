


namespace Banking.Domain;

public class Account
{
    private decimal _currentBalance = 7000;
    public void Deposit(Currency amountToDeposit)
    {
        _currentBalance += amountToDeposit;
    }

    public Currency GetBalance()
    {
        return (Currency)_currentBalance;
    }

    public void Withdraw(Currency amountToWithdraw)
    {

        if (amountToWithdraw > _currentBalance)
        {
            throw new AccountOverdraftException();

        }

        _currentBalance -= amountToWithdraw;

    }
}