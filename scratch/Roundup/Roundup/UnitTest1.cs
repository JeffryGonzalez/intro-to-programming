namespace Roundup;

public class UnitTest1
{

    [Fact]
    public void Test1()
    {
        var myAccount = new Account();
        var yourAccount = new Account();

        //Assert.Equal(5000M, myAccount.GetBalance());
        //Assert.Equal(5000M, yourAccount.GetBalance());

        //myAccount = yourAccount;
        //myAccount.Deposit(1000M);

        //Assert.Equal(6000M, myAccount.GetBalance());
        //Assert.Equal(5000M, yourAccount.GetBalance());
    }

    [Fact]
    public void Test2()
    {
        var account = new Account();
        account.Deposit(10000);


        var reporter = new AccountReporting();
        Assert.Equal(15000, account.Balance);
        reporter.PrintReportForTheAccount(account); // do something with this account
        Assert.Equal(15000, account.Balance);

        int num = 2;
        reporter.DoubleIt(num);
        Assert.Equal(4, num);
    }

    [Fact]
    public void StringsareWeird()
    {
        var word = "Tacos";
        var reporter = new AccountReporting();
        reporter.DoubleIt(word); // overloading

        Assert.Equal("TacosTacos", word);
    }
}


public class Account
{
    private decimal _balance = 5000;

    public void Deposit(decimal amount)
    {
        var speculativeAmount = amount * 1.39M;

        _balance += amount;
    }
    public void Withdraw(decimal amount)
    {
        _balance -= amount;
    }
    // Properties imply no computation, never throw an exception, and are idempotent;
    public decimal Balance
    {
        get
        {
            return _balance;
        }
    }
}

public class AccountReporting
{
    public void PrintReportForTheAccount(Account account)
    {
        // do something with the account
        //  account.Withdraw(account.GetBalance());
    }

    public void AdjustAccountForSettlement(Account peanut)
    {   // I have a new variable in this scope called "peanut" and it's value is...
        peanut.Deposit(100M);
    }

    public void DoubleIt(int x)
    {   // in this scope there is a new variable called "x" with a value of 2
        x = x + x; // I just assigned to "my" x 4, 
    }

    public void DoubleIt(string x)
    {// "Tacos"
        x = "Bologna";
        // TacosTacos
    }


}