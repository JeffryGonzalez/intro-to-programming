
namespace Banking.Tests.Money;
public class CreatingMoney
{
    [Theory]
    [InlineData(100, 23, 100.23)]
    [InlineData(12, 18, 12.18)]
    [InlineData(0, 12, 0.12)]
    public void CanConvert(uint dollars, uint cents, decimal expected)
    {
        var validMoney = TransactionAmount.FromUsd(dollars, cents);
        Assert.Equal(expected, validMoney.GetValue());

        var myPay = TransactionAmount.FromUsd(125, 23);
        decimal pay1 = myPay.GetValue();
        decimal pay2 = myPay;


        Assert.Equal(pay1, pay2);
    }


    [Theory]
    [InlineData(100, 23, 100.23)]
    [InlineData(12, 18, 12.18)]
    public void ImplicitConversion(uint dollars, uint cents, decimal expected)
    {
        var validMoney = TransactionAmount.FromUsd(dollars, cents);
        Assert.Equal<decimal>(expected, validMoney);

    }

    [Theory]
    [InlineData(0, 0)]
    [InlineData(12, 101)]
    public void InvalidValuesForCurrency(uint dollars, uint cents)
    {
        // We can only code our understanding of the rule.
        Assert.Throws<InvalidCurrencyException>(() =>
        {
            TransactionAmount.FromUsd(dollars, cents);
        });


    }
    [Fact]
    public void ExplicitConversionDemo()
    {
        // Note - this is weak, but just here for demonstration purposes.
        TransactionAmount c = (TransactionAmount)123.89M;

        Assert.Equal<uint>(123, c.Dollars);
        Assert.Equal<uint>(89, c.Cents);

    }
}
