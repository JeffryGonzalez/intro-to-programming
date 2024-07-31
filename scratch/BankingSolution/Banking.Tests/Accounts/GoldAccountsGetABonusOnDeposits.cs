

namespace Banking.Tests.Accounts;
public class GoldAccountsGetABonusOnDeposits
{
    [Fact]
    public void BonusAppliedWhenGoldAccount()
    {

        var account = new Account();
        var openingBalance = account.GetBalance();

        account.Deposit((TransactionAmount)100M);

        Assert.Equal(openingBalance + 110M, account.GetBalance());
    }
    [Fact]
    public void BonusNotAppliedToNonGoldAccounts()
    {

        var account = new Account();
        var openingBalance = account.GetBalance();

        account.Deposit((TransactionAmount)100M);

        Assert.Equal(openingBalance, account.GetBalance());
    }
}
