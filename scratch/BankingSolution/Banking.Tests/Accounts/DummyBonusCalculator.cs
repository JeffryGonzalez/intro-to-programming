


namespace Banking.Tests.Accounts;

public class DummyBonusCalculator : ICalculateBonuses
{
    public decimal CalculateBonusForDepositOn(decimal currentBalance, decimal amount)
    {
        return 0;
    }
}