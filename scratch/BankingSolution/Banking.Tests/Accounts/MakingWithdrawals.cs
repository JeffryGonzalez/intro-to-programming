

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

        account.Withdraw((TransactionAmount)amountToWithdraw);

        var newBalance = account.GetBalance();
        Assert.Equal(openingBalance - amountToWithdraw, newBalance);
    }

    [Fact]
    public void CanWithdrawFullBalance()
    {
        var account = new Account();

        // UG-LEE.... needs help.
        account.Withdraw((TransactionAmount)(decimal)account.GetBalance());

        Assert.Equal(0M, account.GetBalance());
    }

}
