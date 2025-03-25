namespace ScriptureMemorizer
{
    public class Reference
    {
        private string _book { get; set; }
        private string _chapter { get; set; }
        private string _verse { get; set; }

        public Reference(string book, string chapter, string verse)
        {
            _book = book;
            _chapter = chapter;
            _verse = verse;
        }

        public string FullReference()
        {
            return $"{_book} {_chapter}:{_verse}";
        }
    }
}