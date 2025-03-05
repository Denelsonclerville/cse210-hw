using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask for the user's age
        Console.Write("Please enter your age: ");
        int age = int.Parse(Console.ReadLine());

        // Determine if the person is "young" ,"adult" and old
        if (age <= 18)
        {
            Console.WriteLine("You are young.");
        }
        else if (age <= 50)
        {
            Console.WriteLine("You are an old person.");
        }
        else
        {
            Console.WriteLine("You are an adult.");
        }
    }
}

