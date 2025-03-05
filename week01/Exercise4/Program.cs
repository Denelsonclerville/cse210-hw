using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for a number
        Console.Write("Enter a number to calculate its factorial: ");
        int number = int.Parse(Console.ReadLine());  // Convert the input to an integer

        // Check if the number is negative
        if (number < 0)
        {
            Console.WriteLine("Factorial is not defined for negative numbers.");
        }
        else
        {
            // Calculate the factorial
            long factorial = 1;
            
            for (int i = 1; i <= number; i++)
            {
                factorial *= i; // Multiply factorial by each number in the loop
            }

            // Output the result
            Console.WriteLine($"The factorial of {number} is {factorial}");
        }
    }
}