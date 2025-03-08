using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int userNumber;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            userNumber = int.Parse(Console.ReadLine());
            if (userNumber != 0)
            {
                numbers.Add(userNumber);
            }
        
        }
        while (userNumber != 0);

        // Calculate sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        
        // Calculate average
        float average = (float)sum / numbers.Count;

        // Find the largest number
        int largest = numbers[0];
        foreach (int number in numbers)
        {
            if (number > largest)
            {
                largest = number;
            }
        
        }
        // Find the smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int number in numbers)
        {
         if (number > 0 && number < smallestPositive)
            {
                smallestPositive = number;
            }
        }
        // Sort the list
        numbers.Sort();

        // Display results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largest}");
        Console.WriteLine($"The smallest positive number is: {smallestPositive}");

        // Display sorted list
        Console.WriteLine("The sorted list is:");
        foreach (int number in numbers)
        {
            Console.WriteLine(number);
        }
        
    }
}