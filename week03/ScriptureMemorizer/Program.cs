using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public class Word
    {
        public string Value { get; set; }
        public bool WordHidden { get; set; }

        public Word(string value)
        {
            Value = value;
            WordHidden = false;
        }
        public string GetDisplayText()
        {
            return WordHidden ? new string('_', Value.Length) : Value;
        }
    }
    public class Scripture
    {
        public string Scripturesimiliar { get; set; }
        public List<Word> Words { get; set; }
        public Scripture(string reference, string text)
        {
            Scripturesimiliar = reference;
            Words = new List<Word>();
            var wordArray = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in wordArray)
            {
                Words.Add(new Word(word));
            }
        }
        public void DisplayScripture()
        {
            Console.Clear();
            Console.Beep();
            Console.Write(Scripturesimiliar + " ");
            foreach (var word in Words)
            {
                Console.Write(word.GetDisplayText() + " ");
            }
            Console.WriteLine("\n");
        }

        public void HideWord()
        {
            var random = new Random();
            var unhiddenWords = Words.Where(w => !w.WordHidden).ToList();

            if (unhiddenWords.Count >= 2)
            {
                Word word1 = unhiddenWords[random.Next(unhiddenWords.Count)];
                Word word2 = unhiddenWords[random.Next(unhiddenWords.Count)];

                while (word1 == word2)
                {
                    word2 = unhiddenWords[random.Next(unhiddenWords.Count)];
                }

                word1.WordHidden = true;
                word2.WordHidden = true;
            }
        }
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
                if (!word.WordHidden)
                {
                    allHidden = false;
                    break;
                }
            }

            if (allHidden)
            {
                Console.WriteLine("The words of this scripture are hidden.");
                break;
            }
        }
    }
}