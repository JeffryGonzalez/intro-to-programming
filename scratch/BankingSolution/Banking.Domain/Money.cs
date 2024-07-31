
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
        decimal result = _dollars + ((decimal)_cents / 100);
        return result;// slime, bs
    }
    public static implicit operator decimal(Currency currency)
    {
        return currency.GetValue();
    }
    public static Currency FromUsd(uint dollars, uint cents)
    {
        if (ArgsAreValid(dollars, cents))
        {
            return new Currency(dollars, cents, "USD");
        }
        else
        {
            throw new InvalidCurrencyException();
        }

    }

    private static bool ArgsAreValid(uint dollars, uint cents)
    {
        if (dollars > 0 && cents > 0)
        {
            if (cents <= 99)
            {
                return true;
            }
        }
        return false;
    }
}
