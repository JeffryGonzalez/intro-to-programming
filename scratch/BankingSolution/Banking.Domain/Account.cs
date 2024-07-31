


namespace Banking.Domain;

public class Account
{
    private decimal _currentBalance = 7000;
    public void Deposit(TransactionAmount amountToDeposit)
    {

        _currentBalance += amountToDeposit * 1.10M;
    }

    public AccountBalance GetBalance()
    {
        return new AccountBalance(this._currentBalance);
    }


    public void Withdraw(TransactionAmount amountToWithdraw)
    {

        if (amountToWithdraw > _currentBalance)
        {
            throw new AccountOverdraftException();

        }

        _currentBalance -= amountToWithdraw;

    }
}