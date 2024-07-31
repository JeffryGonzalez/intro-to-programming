
namespace Banking.Domain;

public class BonusCalculator : ICalculateBonuses
{


    public decimal CalculateBonusForDepositOn(decimal balance, decimal amountToDeposit)
    {
        return balance >= 5000M ? amountToDeposit * .10M : amountToDeposit;
    }
}