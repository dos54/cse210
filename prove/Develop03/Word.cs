using System;
using System.Collections.Concurrent;

public class Word {
    private string _text;
    private bool _isHidden;

    public Word(string word) {
        _text = word;
        _isHidden = false;
    }
    public string GetWord() {
        return _text;
    }
    public void SetWord(string word){
        _text = word;
    }
    public bool GetHidden() {
        return _isHidden;
    }
    public void Hide() {
        _isHidden = true;
    }
    public void Show() {
        _isHidden = false;
    }
    public string GetDisplayText() {
        if (!_isHidden) {
            return _text;
        }
        return new string('_', _text.Length);
    }
}