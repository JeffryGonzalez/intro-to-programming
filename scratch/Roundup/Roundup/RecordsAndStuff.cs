namespace Roundup;
public class RecordsAndStuff
{
    [Fact]
    public void Tacos()
    {

        var bob = new Customer();
        bob.Name = "Robert";
        Assert.Equal("Robert", bob.Name);

        Assert.Equal(0, bob.CreditLimit);
        bob.IncreaseCreditLimit(3000);

        Assert.Equal(3000, bob.CreditLimit);




    }
}

public record Customer
{
    // types (classes) have like two things, data, and code that uses that data, right?
    // data are the variables the object "owns", we call these fields.
    //private string _name;
    public string Name { get; set; } = string.Empty;

    public decimal CreditLimit { get; private set; }
    //private decimal _creditLimit = 5000; //

    //public decimal CreditLimit
    //{
    //    get { return _creditLimit; }
    //    set { _creditLimit = value; }
    //}

    public void IncreaseCreditLimit(decimal amount)
    {
        if (amount > 5000)
        {
            throw new Exception();
        }
        else
        {
            CreditLimit = amount;
        }
    }

}
