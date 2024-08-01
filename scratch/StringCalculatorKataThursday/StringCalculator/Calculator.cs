
public class Calculator
{
    public int Add(string numbers)
    {

        if (numbers == "") return 0;

        var (delimiters, nums) = CleanNumbers(numbers);
        GuardNoNegatives(delimiters, nums);
        return nums
            .Split(delimiters)
            .Select(int.Parse)
            .Where(n => n <= 1000)
            .Sum();
    }

    private static void GuardNoNegatives(char[] delimiters, string nums)
    {
        var negatives = nums.Split(delimiters).Select(int.Parse).Where(n => n < 0).ToList();
        if (negatives.Count > 0)
        {
            throw new NoNegativeNumbersException(string.Join(',', negatives.ToArray()));

        }
    }

    private char[] baseDelimeters = [',', '\n'];
    private (char[] delimeters, string cleanedNumbers) CleanNumbers(string numbers)
    {
        if (numbers.StartsWith("//"))
        {
            var delim = numbers.Substring(2, 1);
            return ([.. baseDelimeters, char.Parse(delim)], numbers[4..]);
        }
        else
        {
            return (baseDelimeters, numbers);
        }
    }
}

public class NoNegativeNumbersException : ArgumentException
{
    public NoNegativeNumbersException(string message) : base(message)
    {
    }
}