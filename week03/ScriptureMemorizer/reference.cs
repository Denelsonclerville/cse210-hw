namespace ScriptureMemorizer
{
    public class Reference
    {
        private string _Book { get; set; }
        private string _Chapter { get; set; }
        private string _Verse { get; set; }

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
}