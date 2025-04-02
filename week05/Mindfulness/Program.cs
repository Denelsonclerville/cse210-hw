using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Mindfulness;

    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Activity Program!");
                Console.WriteLine("1. Start the Breathing Activity");
                Console.WriteLine("2. Start the Reflection Activity");
                Console.WriteLine("3. Start the Listing Activity");
                Console.WriteLine("4. Exit");
                Console.Write("Please select an activity: ");
                string choice = Console.ReadLine();

                Activity activity = null;

                // Activity selection menu
                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        Console.WriteLine("Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid");
                        continue;
                }

                activity.StartActivity();
            }
        }
    }
