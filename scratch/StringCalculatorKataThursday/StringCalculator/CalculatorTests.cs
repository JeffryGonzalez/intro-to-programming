

namespace StringCalculator;
public class CalculatorTests
{
    private readonly Calculator _calculator;
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
    [InlineData("12", 12)]
    [InlineData("3", 3)]
    [InlineData("420", 420)]
    public void CanAddSingleInteger(string input, int expected)
    {
        var result = _calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2", 3)]
    [InlineData("1,3", 4)]
    [InlineData("10,2", 12)]
    [InlineData("88,18", 106)]

    public void TwoDigitsComma(string input, int expected)
    {
        var result = _calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1,2,3", 6)]
    [InlineData("1,2,3,4,5,6,7,8,9", 45)]

    public void ArbitraryLength(string input, int expected)
    {
        var result = _calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("1\n2\n3", 6)]
    [InlineData("8\n10", 18)]
    [InlineData("1\n2,3", 6)]

    public void NewLineDelimeters(string input, int expected)
    {

        var result = _calculator.Add(input);

        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("//#\n1#2", 3)]
    [InlineData("//#\n3#3", 6)]
    [InlineData("//;\n12;8", 20)]
    [InlineData("//~\n12~9", 21)]
    [InlineData("//%\n12%9,1", 22)]

    public void CustomDelimeters(string input, int expected)
    {
        var result = _calculator.Add(input);
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData("-1")]
    [InlineData("2,-1")]

    public void NegativesNumbersNotAllowed(string input)
    {
        Assert.Throws<NoNegativeNumbersException>(() => _calculator.Add(input));
    }

    [Theory]
    [InlineData("-1", "-1")]
    [InlineData("2,-3", "-3")]
    [InlineData("//%\n12%9,1%-19,12,-33", "-19,-33")]
    public void AllNegativesHaveMessageInException(string input, string message)
    {
        var ex = Assert.Throws<NoNegativeNumbersException>(() => _calculator.Add(input));
        Assert.Contains(message, ex.Message);
    }

    [Theory]
    [InlineData("1001", 0)]
    [InlineData("1,2,3,2084,4,5,6,7,8,9,1000,1002", 1045)]

    public void OverThresholdIsNotCounted(string input, int expected)
    {
        var result = _calculator.Add(input);
        Assert.Equal(expected, result);
    }
}
