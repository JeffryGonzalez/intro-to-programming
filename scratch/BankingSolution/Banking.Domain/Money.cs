
namespace Banking.Domain;
public record TransactionAmount
{
    private uint _dollars;
    private uint _cents;
    private string _currency;
    private TransactionAmount(uint dollars, uint cents, string currency)
    {
        _dollars = dollars;
        _cents = cents;
        _currency = currency;
    }
    public decimal GetValue()
    {
        decimal result = _dollars + ((decimal)_cents / 100);
        return result;
    }
    public static implicit operator decimal(TransactionAmount currency)
    {
        return currency.GetValue();
    }
    public static explicit operator TransactionAmount(decimal amount)
    {
        uint dollars = (uint)amount;
        var remainder = amount - dollars;
        uint cents = (uint)(remainder * 100);
        return TransactionAmount.FromUsd(dollars, cents);

    }
    public uint Dollars => _dollars;
    public uint Cents => _cents;
    public static TransactionAmount FromUsd(uint dollars, uint cents)
    {
        if (ArgsAreValid(dollars, cents))
        {
            return new TransactionAmount(dollars, cents, "USD");
        }
        else
        {
            throw new InvalidCurrencyException();
        }
    }

    private static bool ArgsAreValid(uint dollars, uint cents)
    {

        if (dollars == 0)
        {
            if (cents <= 0)
            {
                return false;
            }
        }

        if (cents > 99)
        {
            return false;
        }
        if (dollars == 0 && cents == 0)
        {
            return false;
        }
        return true;


    }
}

public record AccountBalance
{
    private readonly decimal _amount;
    public decimal Balance => _amount;
    internal AccountBalance(decimal amount)
    {
        _amount = amount;
    }
    public static implicit operator decimal(AccountBalance ab)
    {
        return ab.Balance;
    }
}