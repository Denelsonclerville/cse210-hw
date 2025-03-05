using System;

class Program
{
    static void Main(string[] args)
    {
        
        DisplayWelcomeMessage();

        
        string userName = PromptUserName();

        
        int userAge = PromptUserAge();

        int ageInMonths = CalculateAgeInMonths(userAge);

        DisplayResult(userName, ageInMonths);
    }

    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the Age Calculator!");
    }
    // Function to prompt the user for their name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    // Function to prompt the user for their age
    static int PromptUserAge()
    {
        Console.Write("Please enter your age: ");
        int age = int.Parse(Console.ReadLine());

        return age;
    }
    // Function to calculate the age in months
    static int CalculateAgeInMonths(int age)
    {
        return age * 12;  // 1 year = 12 months
    }

    // Function to display the result
    static void DisplayResult(string name, int ageInMonths)
    {
        Console.WriteLine($"{name}, you are {ageInMonths} months old.");
    }
}
