public class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public void Hide()
    {
        _isHidden = true;
    }

    public string GetDisplayText()
    {
        if (_isHidden)
        {
            char[] hidden = new char[_text.Length];
            for (int i = 0; i < _text.Length; i++)
            {
                hidden[i] = Char.IsPunctuation(_text[i]) ? _text[i] : '_';
            }
            return new string(hidden);
        }
        else
        {
            return _text;
        }
    }
}
