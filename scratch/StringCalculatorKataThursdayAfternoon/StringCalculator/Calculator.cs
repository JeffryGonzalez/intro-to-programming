

public class Calculator
{
    private ILogger _logger;
    private IWebService _webService;
    public Calculator(ILogger logger, IWebService webService)
    {
        _logger = logger;
        _webService = webService;
    }

    public int Add(string numbers)
    {
        var response = 0;

        if (numbers == "")
        {
            response = 0;

        }
        else
        {
            response = numbers.Split(',', '\n').Select(int.Parse).Sum();
        }



        try
        {
            _logger.LogMessage(response.ToString());
        }
        catch (Exception)
        {

            _webService.NotifyOfLogFailure(response.ToString());
        }

        return response;
    }
}


public interface ILogger
{
    void LogMessage(string numbers);
}

public interface IWebService
{
    void NotifyOfLogFailure(string message);
}