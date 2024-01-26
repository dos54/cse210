using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        List<Scripture> listScriptures = new();
        string line; 
        try {
            using StreamReader reader = new StreamReader("scriptures.txt");
            line = reader.ReadLine();
            line = reader.ReadLine();
            while (line != null) {
                string[] sections = line.Split("|||");
                string scriptureText = sections[0];
                string book = sections[1];
                int chapter = int.Parse(sections[2]);
                int startVerse = int.Parse(sections[3]);
                int? endVerse = sections.Length > 4 ? int.Parse(sections[4]) : null;
                Reference reference = new(book,chapter,startVerse,endVerse);
                Scripture newScripture = new(reference, scriptureText);
                listScriptures.Add(newScripture);

                line = reader.ReadLine();
            }
        } catch (Exception e) {
            Console.WriteLine($"Error: {e.Message}");
        }

        Scripture scripture;
        while (true) {
            Console.Clear();
            Console.WriteLine("Please choose from one of the following scriptures");
            Console.WriteLine();
            int index = 0;
            foreach (Scripture tempScripture in listScriptures) {
                index++;
                Console.WriteLine($"{index}. {tempScripture.GetDisplayText()}");
            }

            Console.WriteLine();
            Console.WriteLine("Leave empty to choose a random scripture");
            Console.Write("> ");
            string userChoice = Console.ReadLine().Trim();
            if (userChoice == "") {
                Random random = new();
                scripture = listScriptures[random.Next(0, listScriptures.Count)];
                break;
            } else {
                int choice = int.Parse(userChoice);
                if (choice > listScriptures.Count) {
                    Console.WriteLine($"{choice} is not a valid option.");
                    Console.WriteLine("Press enter to continue");
                    Console.Write("> ");
                    Console.ReadLine();
                } else {
                    scripture = listScriptures[choice - 1];
                    break;
                }
            }
        }

        do {
            Console.Clear();
            scripture.DisplayScripture();
            Console.WriteLine();
            Console.WriteLine("Type \"Quit\" to quit, or press enter to continue.");
            string userInput = Console.ReadLine();
            if (userInput.ToLower().Trim() == "quit") {
                break;
            }
            scripture.HideRandomWords(3);
        } while (!scripture.IsCompletelyHidden());
        Console.Clear();
        scripture.DisplayScripture();

    }
}