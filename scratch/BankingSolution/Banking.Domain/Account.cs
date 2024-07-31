


namespace Banking.Domain;

public class Account
{
    private decimal _currentBalance = 7000;
    private ICalculateBonuses _bonusCalculator;

    public Account(ICalculateBonuses bonusCalculator)
    {
        _bonusCalculator = bonusCalculator;
    }

    public void Deposit(TransactionAmount amountToDeposit)
    {

        var bonus = _bonusCalculator.CalculateBonusForDepositOn(_currentBalance, amountToDeposit.GetValue());
        _currentBalance += amountToDeposit + bonus;
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