
namespace Roundup;
public class RefOutStuff
{

    [Fact]
    public void TryingToParseStuff()
    {

        var numbers = "89";
        int possibleNumber;
        if (int.TryParse(numbers, out possibleNumber))
        {
            Assert.Equal(89, possibleNumber);
        }

    }
    [Fact]
    public void Dog()
    {
        var num = 12;
        var mutator = new Mutator();
        mutator.MutateTheInteger(ref num);
        var account = new Account();

        mutator.MutateTheBankAccount(ref account);

        Assert.Equal(8000, account.Balance);


        Assert.Equal(24, num);

    }

    [Fact]
    public void Swaparoo()
    {
        var account1 = new Account();
        account1.Deposit(5000);
        var account2 = new Account();
        var mutator = new Mutator();
        mutator.Swap<Account>(ref account1, ref account2);

        int x = 10, y = 20;

        mutator.Swap<int>(ref x, ref y);

        Assert.Equal(20, x);
        Assert.Equal(10, y);
        Assert.Equal(5000, account1.Balance);
        Assert.Equal(10000, account2.Balance);
    }
}

public class Mutator
{
    public void MutateTheInteger(ref int x)
    {
        x = x * 2;
    }

    public void MutateTheBankAccount(ref Account account)
    {
        account = new Account();
    }

    public void Swap<T>(ref T a, ref T b)
    {
        T t = a;
        a = b;
        b = t;

    }

    public int DoubleIt(int x)
    {
        return x * 2;
    }
}