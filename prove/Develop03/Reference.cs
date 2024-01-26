using System;
using System.Data.SqlTypes;

public class Reference {
    private string _book;
    private int _chapter;
    private int _verse;
    private int? _endVerse;

    public Reference(string book, int chapter, int verse) {
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = null;
    }
    public Reference(string book, int chapter, int startVerse, int? endVerse) {
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }

    public string GetDisplayText() {
        if (_endVerse != null) {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
        return $"{_book} {_chapter}:{_verse}";
    }

    public string GetBook() {
        return _book;
    }
    public void SetBook(string book) {
        _book = book;
    }
    
    public int GetChapter() {
        return _chapter;
    }
    public void SetChapter(int chapter) {
        _chapter = chapter;
    }

    public int GetVerse() {
        return _verse;
    }
    public void SetVerse(int verse) {
        _verse = verse;
    }
    public void SetEndVerse(int verse) {
        _endVerse = verse;
    }
    public void SetVerseRange(int startVerse, int endVerse) {
        _verse = startVerse;
        _endVerse = endVerse;
    }

}