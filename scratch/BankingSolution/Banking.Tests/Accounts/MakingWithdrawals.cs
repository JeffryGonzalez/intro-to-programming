
using Banking.Domain;

namespace Banking.Tests.Accounts;
public class MakingWithdrawals
{

    [Theory]
    [InlineData(100)]
    [InlineData(112.25)]
    public void WithdrawalsDecreaseBalance(decimal amountToWithdraw)
    {
        var account = new Account();
        var openingBalance = account.GetBalance();

        account.Withdraw(amountToWithdraw);

        var newBalance = account.GetBalance();
        Assert.Equal(openingBalance - amountToWithdraw, newBalance);
    }

}
