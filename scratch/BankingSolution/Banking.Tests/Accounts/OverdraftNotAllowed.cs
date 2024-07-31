

namespace Banking.Tests.Accounts;
public class OverdraftNotAllowed
{
    [Fact]
    public void OverdraftDoesNotDecreaseBalance()
    {
        var account = new Account(new DummyBonusCalculator());
        var openingBalance = account.GetBalance();


        Assert.Throws<AccountOverdraftException>(
            () => account.Withdraw(((TransactionAmount)(openingBalance + .01M)))
            );

        Assert.Equal(openingBalance, account.GetBalance());
    }


}
