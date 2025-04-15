using System;
using System.Collections.Generic;
using System.IO;
//using EternalQuest;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();
        string userChoice = "";
        //Console.WriteLine($"\nYou have: {goalManager.GetScore()} points\n");
        while (userChoice != "7")
        {
            Console.WriteLine($"\nYou have: {goalManager.GetScore()} points\n");        
            Console.WriteLine("=== Menu Option ===");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Show Score and Level");
            Console.WriteLine("7. Quit");
            Console.Write("Select an option from the menu: ");
            userChoice = Console.ReadLine();

            switch (userChoice)
            {
                case "1":
                    goalManager.CreateGoal();
                    break;

                case "2":
                    goalManager.ListGoals();
                    break;

                case "3":
                    Console.Write("Enter a filename to save goals: ");
                    string saveFile = Console.ReadLine();
                    goalManager.SaveToFile(saveFile);
                    break;

                case "4":
                    Console.Write("Enter a filename to load goals: ");
                    string loadFile = Console.ReadLine();
                    goalManager.LoadFromFile(loadFile);
                    break;

                case "5":
                    goalManager.RecordEvent();
                    break;

                case "6":
                    goalManager.ListGoals();
                    break;

                case "7":
                    Console.WriteLine("Goodbye!");
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }

            Console.WriteLine();
        }
    }
}