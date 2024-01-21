using System;

public class Entry {
    //Attributes
    public string _entryText;
    public string _dateTime;
    public string _promptText;

    public void Display() {
        Console.WriteLine($"Date: {_dateTime} - Prompt: {_promptText}");
        Console.WriteLine(_entryText);
    }


}