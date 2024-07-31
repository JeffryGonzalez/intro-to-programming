

namespace Banking.Tests.Accounts;
public class GoldAccountsGetABonusOnDeposits
{
    [Fact]
    public void BonusApplied()
    {

        var account = new Account();
        var openingBalance = account.GetBalance();

        account.Deposit((TransactionAmount)100M);

        Assert.Equal(openingBalance + 110M, account.GetBalance());
    }
}
