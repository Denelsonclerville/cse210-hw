namespace ScriptureMemorizer
{
    public class Word
    {
        private string _value { get; set; }
        public bool _wordHidden { get; set; }

        public Word(string value)
        {
            _value = value;
            _wordHidden = false;
        }

        public string GetDisplayText()
        {
            return _wordHidden ? new string('_', _value.Length) : _value;
        }

        public string GetValue() => _value; 
    }
 
}