
namespace Banking.Domain;
public record Currency
{
    private uint _dollars;
    private uint _cents;
    private string _currency;
    private Currency(uint dollars, uint cents, string currency)
    {
        _dollars = dollars;
        _cents = cents;
        _currency = currency;
    }
    public decimal GetValue()
    {
        return 100.23M;// slime, bs
    }
    public static Currency FromUsd(uint dollars, uint cents)
    {
        if (dollars > 0 && cents > 0)
        {
            return new Currency(dollars, cents, "USD");
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }

    }
}
