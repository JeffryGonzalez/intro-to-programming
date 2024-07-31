
namespace Banking.Tests.Money;
public class CreatingMoney
{
    [Fact]
    public void HappyPath()
    {
        uint dollars = 100;
        uint cents = 23;

        var validMoney = Currency.FromUsd(dollars, cents);


        Assert.Equal(100.23M, validMoney.GetValue());

    }

    [Fact]

    public void BadPath()
    {
        //var dollars = 0;
        //var cents = 23;

        var validMoney = Currency.FromUsd(23, 0);


    }
}
