

namespace StringCalculator;
public class CalculatorTests
{
    private Calculator _calculator;
    public CalculatorTests()
    {
        _calculator = new Calculator();
    }


    [Fact]
    public void EmptyStringReturnsZero()
    {

        var result = _calculator.Add("");

        Assert.Equal(0, result);
    }

    [Theory]
    [InlineData("99", 99)]
    [InlineData("13", 13)]
    [InlineData("4096", 4096)]
    [InlineData("1,2", 3)]
    public void SingleInteger(string example, int expected)
    {

        var result = _calculator.Add(example);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("3,3", 6)]
    [InlineData("8,8", 16)]
    [InlineData("10,2", 12)]
    public void TwoIntegers(string example, int expected)
    {

        var result = _calculator.Add(example);
        Assert.Equal(expected, result);
    }


}
