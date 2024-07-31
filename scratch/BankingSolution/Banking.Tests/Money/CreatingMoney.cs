
namespace Banking.Tests.Money;
public class CreatingMoney
{
    [Theory]
    [InlineData(100, 23, 100.23)]
    [InlineData(12, 18, 12.18)]
    public void HappyPath(uint dollars, uint cents, decimal expected)
    {
        var validMoney = Currency.FromUsd(dollars, cents);
        Assert.Equal(expected, validMoney.GetValue());
        decimal amount = validMoney;
        Assert.Equal(expected, amount);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(101)]
    public void BadPath(uint cents)
    {
        Assert.Throws<InvalidCurrencyException>(() =>
        {
            Currency.FromUsd(1, cents);
        });


    }
}
