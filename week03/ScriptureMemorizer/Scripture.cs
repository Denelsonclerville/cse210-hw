namespace ScriptureMemorizer
{
   public class Scripture
    {
        private string FullReference { get; set; }
        public List<Word> Words { get; set; }
        public List<Word> HiddenWords { get; private set; }

        public Scripture(string reference, string text)
        {
            FullReference = reference;
            Words = new List<Word>();
            HiddenWords = new List<Word>();
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
            Console.Write(FullReference + " ");
            foreach (var word in Words)
            {
                Console.Write(word.GetDisplayText() + " ");
            }
            Console.WriteLine("\n");
        }

        public void HideWord()
        {
            var random = new Random();
            var unhiddenWords = Words.Where(w => !w._WordHidden).ToList();

            if (unhiddenWords.Count >= 2)
            {
                Word word1 = unhiddenWords[random.Next(unhiddenWords.Count)];
                unhiddenWords.Remove(word1);  // Remove the first selected word to avoid repetition
                Word word2 = unhiddenWords[random.Next(unhiddenWords.Count)];

                word1._WordHidden = true;
                word2._WordHidden = true;
                HiddenWords.Add(word1);
                HiddenWords.Add(word2);
            }
        }
    } 
}