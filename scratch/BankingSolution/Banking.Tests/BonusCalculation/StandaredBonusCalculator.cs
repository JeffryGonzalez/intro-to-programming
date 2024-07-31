namespace Banking.Tests.BonusCalculation;
public class StandaredBonusCalculator
{
    [Fact]
    public void GivesBonusToAccountsWithSufficientBalance()
    {
        var bonusCalculator = new BonusCalculator();
        decimal balance = 5000M;
        decimal amountToDeposit = 100M;

        decimal bonus = bonusCalculator.CalculateBonusForDepositOn(balance, amountToDeposit);

        Assert.Equal(10M, bonus);
    }
}
