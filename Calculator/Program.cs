// See https://aka.ms/new-console-template for more informatio
using CalculatorApp;
using System.Threading.Channels;

bool endApp = false;

Console.WriteLine("Welcome to a calculator app!");
Console.WriteLine("---------------------------");

while (!endApp)
{
    string? numInput1 = "";
    string? numInput2 = "";
    double result = 0;

    Console.Write("Type a number, and then press enter: ");
    numInput1 = Console.ReadLine();

    double num1 = 0;
    while (!double.TryParse(numInput1, out num1))
    {
        Console.WriteLine("This is not a valid input, please enter an integer number:");
        numInput1 = Console.ReadLine();
    }

    Console.Write("Type the second number, and then press enter: ");
    numInput2 = Console.ReadLine();

    double num2 = 0;
    while (!double.TryParse(numInput2, out num2))
    {
        Console.WriteLine("This is not a valid input, please enter an integer number:");
        numInput2 = Console.ReadLine();
    }

    Console.Write("Now, pick a correct operation: \n\ta - addition \n\ts - subtraction" +
        "\n\tm - multiplication \n\td - division \nYour option? ");

    string? op = Console.ReadLine();

    try
    {
        result = Calculator.DoOperation(num1, num2, op);
        while (double.IsNaN(result))
        {
            Console.WriteLine("The input is not valid, pick an operation from the list above: ");
            result = Calculator.DoOperation(num1, num2, op = Console.ReadLine());
        }
        Console.WriteLine("The result is {0:0.##}\n", result); 
    }
    catch (Exception e)
    {
        Console.WriteLine("Oh no! An exception occurred trying to do the math.\n - Details: " + e.Message);
    }

    Console.WriteLine("If you want to continue - press enter. " +
        "If you want to close the app - press \"n\" and then enter");

    if(Console.ReadLine() == "n")
        endApp = true;
}




