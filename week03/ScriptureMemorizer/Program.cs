using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public class Word
    {
        private string _Value { get; set; }
        public bool _WordHidden { get; set; }

        public Word(string value)
        {
            _Value = value;
            _WordHidden = false;
        }
        public string GetDisplayText()
        {
            return _WordHidden ? new string('_', _Value.Length) : _Value;
        }
    }


    // Define the reference
     public class Reference
    {
        private string _Book { get; set; }
        private string _Chapter { get; set; }
        private string _Verse { get; set; }

        // Constructor to initialize Book, Chapter, and Verse
        public Reference(string book, string chapter, string verse)
        {
            _Book = book;
            _Chapter = chapter;
            _Verse = verse;
        }

        public string FullReference()
        {
            return $"{_Book} {_Chapter}:{_Verse}";
        }
    }

    // Define the Scripture class
    public class Scripture
    {
        private string FullReference { get; set; }
        public List<Word> Words { get; set; }
        public Scripture(string reference, string text)
        {
            FullReference = reference;
            Words = new List<Word>();
            var wordArray = text.Split(new[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var word in wordArray)
            {
                Words.Add(new Word(word));
            }
        }

        // Display the reference and the text
        public void DisplayScripture()
        {
            Console.Clear();
            Console.Beep();
            Console.Write(FullReference + " ");
            foreach (var word in Words)
            {
                Console.Write(word.GetDisplayText() + " ");
            }
            Console.WriteLine("\n");
        }


        // hide words
        public void HideWord()
        {
            var random = new Random();
            var unhiddenWords = Words.Where(w => !w._WordHidden).ToList();

            if (unhiddenWords.Count >= 2)
            {
                Word word1 = unhiddenWords[random.Next(unhiddenWords.Count)];
                Word word2 = unhiddenWords[random.Next(unhiddenWords.Count)];

                while (word1 == word2)
                {
                    word2 = unhiddenWords[random.Next(unhiddenWords.Count)];
                }

                word1._WordHidden = true;
                word2._WordHidden = true;
            }
        }
    }


     // The main program
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

            if (allHidden)
            {
                Console.WriteLine("Stop pressing!\n");
                break;
            }
        }
    }
}