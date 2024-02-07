using System.Collections;

namespace ConsoleApp1;

class Program
{
    private static readonly char[] Operations = ['+', '-', '*', '/'];
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter expression to evaluate (left to right):");
        string? userInput;
        for (;;)
        {
            // Repeatedly ask until we get a non-empty and usable string
            userInput = Console.ReadLine();
            if (!String.IsNullOrEmpty(userInput))
            {
                break;
            }
            Console.WriteLine("Invalid!");
        }

        // Convert strings to doubles
        double[] nums = ConvertToDoubleArray(userInput.Split(Operations));

        // Extract operators from the string
        ArrayList ops = [];
        foreach (char c in userInput)
        {
            if (Operations.Contains(c))
            {
                ops.Add(c);
            }
        }

        // Perform calculations
        double res = 0;
        foreach (double d in nums)
        {
            if (res == 0)
            {
                // The first number will not have an operator as it is the start of the expression
                // so we will need to set the result to the first number
                res = d;
                continue;
            }
            // Queue up the next operator
            char currentOperator = (char) ops[0];
            ops.RemoveAt(0);
            // Perform the operation
            switch (currentOperator)
            {
                case '+':
                    res += d;
                    break;
                case '-':
                    res -= d;
                    break;
                case '*':
                    res *= d;
                    break;
                case '/':
                    res /= d;
                    break;
            }
        }
        Console.WriteLine(res);
    }

    /// <summary>
    /// Convert a string array to a double array
    /// </summary>
    /// <param name="strings">an array of strings</param>
    /// <returns>an array of doubles</returns>
    /// <exception cref="ArgumentException">if a cast was unsuccessful</exception>
    private static double[] ConvertToDoubleArray(string[] strings)
    {
        double[] res = new double[strings.Length];
        for (int i = 0; i < strings.Length; i++)
        {
            if (double.TryParse(strings[i], out double result))
            {
                res[i] = result;
            }
            else
            {
                throw new ArgumentException("Invalid expression: " + strings[i]);
            }
        }
        return res;
    }
}