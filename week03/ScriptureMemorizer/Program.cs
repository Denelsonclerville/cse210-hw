using System;
using System.Collections.Generic;
using System.Linq;
using ScriptureMemorizer;

class Program
{
    static string HideAllWord(string text, List<string> mots)
    {
        foreach (var mot in mots)
        {
            text = text.Replace(mot, new string('_', mot.Length));
        }
        return text;
    }

    static void Main(string[] args)
    {
        var reference = "Matthew 12:12-13";
        var text = "How much then is a man better than a sheep? Wherefore it is lawful to do well on the sabbath days, then saith he to the man, Stretch forth thine hand. And he stretched it forth; and it was restored whole, like asthe other.";

        var scripture = new Scripture(reference, text);
        scripture.DisplayScripture();

        while (true)
        {
            Console.WriteLine("Press Enter to continue or type 'quit' to finish.");
            Console.Write(">");
            string user = Console.ReadLine().ToLower();
            if (user == "quit")
            {
                break;
            }

            scripture.HideWord();
            scripture.DisplayScripture();

            bool allHidden = true;
            foreach (var word in scripture.Words)
            {
                if (!word._WordHidden)
                {
                    allHidden = false;
                    break;
                }
            }
            /* My Creativity
            Ask the User to guess a word in the scripture*/

            if (allHidden)
            {
                Console.WriteLine("Stop pressing!\nAll words in the scripture have been hidden.\n");
                Console.Write("Type your first name: ");
                string userName = Console.ReadLine();
                userName = ToTitlecase(userName);

                List<string> word3 = scripture.HiddenWords.Select(w => w.GetValue().ToLower()).ToList();

                Console.WriteLine($"Welcome {userName} !");

                bool game = true;
                Random rand = new Random();

                // Shuffle the list of words to guess
                var hiddenWordsCopy = new List<string>(word3);
                int currentWordIndex = 0;

                while (game && hiddenWordsCopy.Count > 0)
                {
                    string wordToGuess = scripture.HiddenWords[rand.Next(scripture.HiddenWords.Count)].GetValue();
                    // Select the next word to be guessed

                    string TextWithHiddenword = HideAllWord(text, hiddenWordsCopy);
                    Console.WriteLine($"\nhint:\n  {TextWithHiddenword}\n");

                    // Randomly select one word from the HiddenWords list for the user to guess
                    


                    bool foundWord = false;

                    while (!foundWord)
                    {
                        Console.Write("Guess a word in the scripture: ");
                        string tentative = Console.ReadLine().Trim().ToLower();

                        if (word3.Contains(tentative))
                        {
                            Console.WriteLine("Congrats! You guessed the correct word.");
                            word3.Remove(tentative);  // Remove the word from the list
                            foundWord = true;
                            currentWordIndex++;
                            break; 
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, that's not the correct word, the word was. Try again.");
                        }
                    }

                    if (word3.Count > 0)
                    {
                        Console.Write("Do you want to retry? (yes/no): ");
                        string reponse = Console.ReadLine().ToLower();

                        if (reponse != "yes")
                        {
                            game = false;
                            Console.WriteLine($"Well done!, the word is {wordToGuess}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("All words have been guessed! Well done, goodbye.");
                        game = false;
                    }
                }
            }
        }
    }

    public static string ToTitlecase(string userName)
    {
        return string.Join(" ", userName.Split(' ')
                                        .Select(word => word.Length > 0 
                                                        ? char.ToUpper(word[0]) + word.Substring(1).ToLower() 
                                                        : ""));
    }
}