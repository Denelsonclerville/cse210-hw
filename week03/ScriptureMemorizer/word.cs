namespace ScriptureMemorizer
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

        public string GetValue() => _Value; 
    }
 
}