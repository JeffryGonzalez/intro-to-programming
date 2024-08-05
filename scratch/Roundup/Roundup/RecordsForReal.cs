namespace Roundup;
public class RecordsForReal
{
    [Fact]
    public void SavingsStuff()
    {
        var mySavingsAccount = new SavingsAccount("989");

        Assert.Equal(5000M, mySavingsAccount.Balance);

        var summary = mySavingsAccount.GetSummary();

        Assert.Equal(5000M, summary.CurrentBalance);
        Assert.Equal("989", summary.AccountId);

        //  summary.CurrentBalance = 90000M;
        var expected = new AccountSummary(5000M, "989");

        Assert.Equal(expected, summary);

        var updatedSummary = summary
            with
        { CurrentBalance = summary.CurrentBalance * 2 };

        Assert.Equal(5000M, summary.CurrentBalance);
        Assert.Equal(10000M, updatedSummary.CurrentBalance);
        Assert.Equal("989", updatedSummary.AccountId);
    }
}

public class SavingsAccount
{
    public SavingsAccount(string id)
    {
        AccountId = id;
    }
    public decimal Balance { get; private set; } = 5000M;
    public string AccountId { get; set; } = string.Empty;

    public AccountSummary GetSummary()
    {
        return new AccountSummary(Balance, AccountId);

        //var summary = new AccountSummary();
        //summary.CurrentBalance = Balance;
        //summary.AccountId = AccountId;
        //return summary;
    }
}

public record AccountSummary(decimal CurrentBalance, string AccountId);
