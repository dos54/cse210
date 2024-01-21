using System;
using System.Xml.Linq;
using System.IO;

public class Journal {
    public List<Entry> _entries = new();

    //Saves the journal entry to a file
    public void SaveToFile(string fileName) {
        using StreamWriter outputFile = new(fileName);
        foreach (Entry entry in _entries)
        {
            outputFile.WriteLine($"{entry._dateTime}|||{entry._promptText}|||{entry._entryText}");
        }
    }

    // Load the journal entry from a file
    public void LoadFromFile(string fileName) {
        List<Entry> entries = new();
        string[] lines;
        try {
            lines = System.IO.File.ReadAllLines(fileName);
        }
        catch {
            Console.WriteLine($"No such file named '{fileName}'");
            return;
        }
        foreach (string line in lines) {
            string[] parts = line.Split("|||");
            Entry entry = new(){
                _dateTime = parts[0],
                _promptText = parts[1],
                _entryText = parts[2]
            };
            AddEntry(entry);
        }
    }

    // Adds a new entry to a journal
    public void AddEntry(Entry entry) {
        _entries.Add(entry);
    }

    // Displays the entire journal
    public void DisplayAll() {
        foreach (Entry entry in _entries) {
            entry.Display();
            Console.WriteLine();
        }
    }
}