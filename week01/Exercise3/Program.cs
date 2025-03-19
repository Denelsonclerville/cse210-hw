using System;
using System.Net;
using System.Linq;


internal class Program
{
    private static void Main(string[] args)
    {
        Random randomGenerator = new Random();
        int listNumber = randomGenerator.Next(1, 101); // Generates a number between 1 and 100

        int guess = -1;
        int attempts = 0;
        int maxAttempts = 5;

        Console.WriteLine("Welcome, try to guess the number between 1 and 100.");

        while (guess != listNumber && attempts < maxAttempts)
        {
            Console.Write("What is your guess? ");
            attempts++;

            if (listNumber > guess)
            {
                Console.WriteLine("Higher");
            }
            else if (listNumber < guess)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("You guessed it! Congratulations!");
                break;
            }
        
        }       
           
            while (attempts == maxAttempts && guess != listNumber)
            {
              Console.WriteLine($"Sorry! You've reached the maximum number of attempts ({maxAttempts}). The correct number was {listNumber}.");
            

            if(attempts == maxAttempts && guess != listNumber)

            {
              Console.WriteLine($"your attempts {attempts}.");
            }

              Console.Write("do you want to replay (yes or no)");
              string replay = Console.ReadLine().ToLower();

              if (replay == "no")
              {
                Console.WriteLine("Thanks for playing");
              } 

              else if  (replay == "yes")
            while (attempts == maxAttempts && guess != listNumber)
              {  
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                attempts++;

                if (listNumber > guess)
                {
                  Console.WriteLine("Higher");
                }
                else if (listNumber < guess)
                {
                Console.WriteLine("Lower");
                }
                else
                {
                Console.WriteLine("You guessed it! Congratulations!");
                break;
                }
              }
               
            }  
              
    }
}