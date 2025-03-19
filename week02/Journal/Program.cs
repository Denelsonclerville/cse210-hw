using System;
using System.Collections.Generic;
using System.IO;


class Program
{
    // List to store journal entries
    static List<JournalEntry> journalEntries = new List<JournalEntry>();

    // List of sample prompts
    static List<string> prompts = new List<string>
    {
        "If I had one thing I could do over today, what would it be?",
        "What was the best part of your day?",
        "What did you learn today?",
        "Who will you ask over today?",
        "what will you do at 20h?"
    };

    static void Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning)
        {
            // Display menu
            Console.WriteLine("Welcome to the journal program!");
            Console.WriteLine("Please select one of the following choices: ");
            Console.WriteLine("1, Write");
            Console.WriteLine("2, Display");
            Console.WriteLine("3, Load");
            Console.WriteLine("4, Save");
            Console.WriteLine("5, Quit");

            // Get user input for action choice
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    WriteEntry();
                    break;
                case "2":
                    DisplayEntries();
                    break;
                case "3":
                    LoadEntries();
                    break;
                case "4":
                    SaveEntries();
                    break;
                case "5":
                    // QuitEntry();
                    Console.WriteLine("your journal was created with your data as well ");
                    isRunning = false;
                    break;
                
            }
        }
    }

    // Method to write a new journal entry
    static void WriteEntry()
    {
        // Choose a random prompt from the list
        Random random = new Random();
        string prompt = prompts[random.Next(prompts.Count)];

        Console.WriteLine(prompt);
        Console.Write("> ");

        // Create new entry with current date
        JournalEntry newEntry = new JournalEntry
        {
           Date = DateTime.Now.ToString(""),
           //DateTime theCurrentTime = DateTime.Now;
            Prompt = prompt,
        };

        journalEntries.Add(newEntry);
    }

    // Method to display all journal entries
    static void DisplayEntries()
    {
        foreach (var entry in journalEntries)
        {
            Console.WriteLine($"Date: {entry.Date} - Prompt: {entry.Prompt}\n ");
        }
        
    }

    
    // Method to load journal entries from a file
    static void LoadEntries()
    {
        Console.Write("What is the filename? ");
        string filename = Console.ReadLine();

        try
        {
            if (File.Exists(filename))
            {
                journalEntries.Clear();
                string[] lines = File.ReadAllLines(filename);

                foreach (var line in lines)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length == 3)
                    {
                        journalEntries.Add(new JournalEntry
                        {
                            Date = parts[0],
                            Prompt = parts[1],
                            Response = parts[2]
                        });
                    }
                }
                Console.WriteLine("Journal loaded successfully.");
            }
            else
            {
                Console.WriteLine("The file does not exist.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading file: {ex.Message}");
        }
    }

    // Method to save journal entries to a file
    static void SaveEntries()
    {
        Console.Write("Enter your filename? ");
        string filename = Console.ReadLine();
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (var entry in journalEntries)
                
            writer.WriteLine("{entry.Date}|{entry.Prompt}|{entry.Response}");
        }
    }

    
}

// JournalEntry class to represent an individual entry in the journal
class JournalEntry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }
}
