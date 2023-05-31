using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace CalculatorApp
{
    public static class Calculator
    {
        public static double DoOperation(double num1, double num2, string op)
        {
            double result = double.NaN;
            switch (op)
            {
                case "a":
                    result = num1 + num2;
                    break;
                case "s":
                    result = num1 - num2;
                    break;
                case "m":
                    result = num1 * num2;
                    break;
                case "d":
                    while (num2 == 0)
                    {
                        Console.WriteLine("It's not possible to divide by zero. " +
                            "Please, pick a number above:");
                        num2 = DealWithAZeroInput(num2);
                    }
                    result = num1 / num2;
                    break;
                default:
                    break;
            }
            return result;
        }

        public static double DealWithAZeroInput(double num2)
        {
            if (!double.TryParse(Console.ReadLine(), out num2))
            {
                Console.WriteLine("Invalid input, type an integer number: ");
                return DealWithAZeroInput(num2);
            }
            else
                return num2;
        }
    }
}

