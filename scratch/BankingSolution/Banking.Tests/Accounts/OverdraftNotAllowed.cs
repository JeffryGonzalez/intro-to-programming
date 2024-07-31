

namespace Banking.Tests.Accounts;
public class OverdraftNotAllowed
{
    [Fact]
    public void OverdraftDoesNotDecreaseBalance()
    {
        var account = new Account();
        var openingBalance = account.GetBalance();

        account.Withdraw(openingBalance + .01M);

        Assert.Equal(openingBalance, account.GetBalance());

    }


}
