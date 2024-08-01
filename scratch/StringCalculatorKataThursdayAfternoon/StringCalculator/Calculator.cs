
public class Calculator
{
    public int Add(string numbers)
    {

        if (numbers == "") { return 0; }

        return numbers.Split(',', '\n').Select(int.Parse).Sum();
    }
}
