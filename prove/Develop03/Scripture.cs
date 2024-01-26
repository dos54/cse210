using System;

public class Scripture {
    private List<Word> _words;
    private Reference _reference;
    private int _numHiddenWords;

    public Scripture(Reference reference, string text) {
        _words = new();
        SetReference(reference);
        SetText(text);
    }

    public void HideRandomWords(int numberToHide) {
        Random random = new();
        if (_words.Count - _numHiddenWords < numberToHide) {
            numberToHide = _words.Count - _numHiddenWords;
        }

        for (int i = 0; i < numberToHide; i++) {
            int randomIndex = random.Next(0, _words.Count);
            if (_words[randomIndex].GetHidden()) {
                i--;
                continue;
            }
            _words[randomIndex].Hide();
            _numHiddenWords++;
        }
    }

    public void DisplayScripture() {
        Console.WriteLine(GetDisplayText());
    }

    public string GetDisplayText() {
        string displayText = "";
        foreach (Word word in _words){
            displayText += $"{word.GetDisplayText()} ";
        }
        return $"{_reference.GetDisplayText()} {displayText}";
    }

    public bool IsCompletelyHidden() { 
        foreach (Word word in _words) {
            if (!word.GetHidden()) {
                return false;
            }
        }
        return true;
    }

    public void SetText(string text) {
        text = text.Replace('\u00A0', ' ');
        string[] textArray = text.Split(" ");
        foreach (string word in textArray) {
            Word newWord = new Word(word);
            _words.Add(newWord);
        }
    }

    public void SetReference(Reference reference) {
        _reference = reference;
    }
    public Reference GetReference() {
        return _reference;
    }


}