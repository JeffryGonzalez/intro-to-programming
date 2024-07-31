namespace Banking.Domain;

public interface ICalculateBonuses
{
    decimal CalculateBonusForDepositOn(decimal currentBalance, decimal amount);
}