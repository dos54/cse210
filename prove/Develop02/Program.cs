using System;
using System.IO.Enumeration;

class Program
{
    static void Main(string[] args)
    {
        DateTime today = DateTime.Today;
        string date = today.ToString("dd-MM-yyyy");

        Journal currentJournal = new();

        string strChoice;
        int choice = 0;
        do
        {
            Console.WriteLine("Welcome to the Journal program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            strChoice = Console.ReadLine();

            try {
                    choice = int.Parse(strChoice);
                }
                catch {
                    Console.WriteLine($"{strChoice} is not a number. Please enter a number!");
                    Console.WriteLine();
                    continue;
                }

            switch (choice) {

                case 1: //Write
                    PromptGenerator prompt = new();
                    Entry entry = new() {
                        _dateTime = date,
                        _promptText = prompt.GeneratePrompt(),
                    };
                    Console.WriteLine(entry._promptText);
                    Console.Write("> ");
                    entry._entryText = Console.ReadLine();
                    currentJournal.AddEntry(entry);
                    break;

                case 2: //Display
                    currentJournal.DisplayAll();
                    break;

                case 3: //Load
                    Console.WriteLine("What is the file name?");
                    string loadFileName = Console.ReadLine();
                    currentJournal.LoadFromFile(loadFileName);
                    break;

                case 4: //Save
                    Console.WriteLine("What is the file name?");
                    string fileName = Console.ReadLine();
                    currentJournal.SaveToFile(fileName);
                    break;

                case 5: //Quit
                    break;

                default:
                    Console.WriteLine($"{choice} is not a valid option.");
                    Console.WriteLine();
                    break;
            }
        } while (choice != 5);

    }
}