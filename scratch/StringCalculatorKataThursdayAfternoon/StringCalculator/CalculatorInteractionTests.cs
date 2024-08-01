
namespace StringCalculator;
public class CalculatorInteractionTests
{


    [Theory]
    [InlineData("3", "3")]
    [InlineData("18", "18")]
    [InlineData("", "0")]

    public void WritesResultToTheLog(string numbers, string expectedLogMessage)
    {
        // Given
        var mockedLogger = Substitute.For<ILogger>();
        var webService = Substitute.For<IWebService>();
        var calculator = new Calculator(mockedLogger, webService);
        // When
        calculator.Add(numbers);

        // Then 
        mockedLogger.Received(1).LogMessage(expectedLogMessage);
        webService.DidNotReceive().NotifyOfLogFailure(Arg.Any<string>());
    }

    [Fact]
    public void WhenLoggerThrowsWebServiceIsCalled()
    {
        // Given
        var stubbedLogger = Substitute.For<ILogger>();
        var mockedWebService = Substitute.For<IWebService>();
        var calculator = new Calculator(stubbedLogger, mockedWebService);
        stubbedLogger.When(m => m.LogMessage(Arg.Any<string>())).Throw(new Exception());
        // When
        calculator.Add("15");
        // Then
        // verifies the web service was called.
        mockedWebService.Received(1).NotifyOfLogFailure("15");
    }
}
