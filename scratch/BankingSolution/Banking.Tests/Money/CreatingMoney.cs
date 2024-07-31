
namespace Banking.Tests.Money;
public class CreatingMoney
{
    [Theory]
    [InlineData(100, 23, 100.23)]
    [InlineData(12, 18, 12.18)]
    public void CanConvert(uint dollars, uint cents, decimal expected)
    {
        var validMoney = Currency.FromUsd(dollars, cents);
        Assert.Equal(expected, validMoney.GetValue());

    }


    [Theory]
    [InlineData(100, 23, 100.23)]
    [InlineData(12, 18, 12.18)]
    public void ImplicitConversion(uint dollars, uint cents, decimal expected)
    {
        var validMoney = Currency.FromUsd(dollars, cents);
        Assert.Equal<decimal>(expected, validMoney);

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
    [Fact]
    public void ExplicitConversionDemo()
    {
        // Note - this is weak, but just here for demonstration purposes.
        Currency c = (Currency)123.89M;

        Assert.Equal<uint>(123, c.Dollars);
        Assert.Equal<uint>(89, c.Cents);

    }
}
