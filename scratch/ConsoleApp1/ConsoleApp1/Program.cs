
Console.WriteLine("Welcome to Super App!");
Console.Write("What is your name? ");
var name = Console.ReadLine();

Console.Write("What is your age? ");
var enteredAge = Console.ReadLine();

if (int.TryParse(enteredAge, out var age))
{

    if (age >= 21)
    {
        Console.WriteLine("Have a beer!");
    }
    else
    {
        Console.WriteLine("Have a root beer");
    }
}
else
{
    Console.WriteLine("You are a moron. Ages are numbers");
}
Console.WriteLine($"Welcome {name} you are {age}");