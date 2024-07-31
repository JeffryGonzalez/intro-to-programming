

using NSubstitute;

namespace Banking.Tests.Accounts;
public class AccountDepositsUseTheBonusCalculator
{
    [Fact]
    public void UsesTheCalculator()
    {
        var stubbedCalulator = Substitute.For<ICalculateBonuses>();
        stubbedCalulator.CalculateBonusForDepositOn(7000M, 100M).Returns(42.69M);

        var account = new Account(stubbedCalulator);
        var openingBalance = account.GetBalance();
        account.Deposit((TransactionAmount)100M);

        Assert.Equal(142.69M + openingBalance, account.GetBalance());



    }
}


//public class StubbedBonusCalculator : ICalculateBonuses
//{
//    public decimal CalculateBonusForDepositOn(decimal currentBalance, decimal amount)
//    {
//        if (currentBalance == 7000M && amount == 100M)
//        {
//            return 42.69M;
//        }
//        else
//        {
//            return 0;
//        }
//    }
//}