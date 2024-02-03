using System;
using System.Collections.Generic;

// Because MenuOption class is simple and only exists for the menu class, I'm leaving it in the same file.
public class MenuOption {
    public string Name {get; set;}
    public Action Action {get; set;}

    public MenuOption(string name, Action action) {
        Name = name;
        Action = action;
    }
}


public class Menu {
    List<MenuOption> _options = new();
    private MenuOption _quit = new("Quit", Quit);
    public void AddOption(string name, Action action) {
        MenuOption menuOption = new(name, action);
        _options.Remove(_quit);
        _options.Add(menuOption);
        _options.Add(_quit);
    }

    private static void Quit() {
        Environment.Exit(0);
    }

    /// <summary>
    /// Create and run the menu. Only runs if the menu includes options.
    /// </summary>
    /// <param name="displayMessage">Message that is displayed that the top of the menu</param>
    /// <param name="clearConsole">Whether the menu should first clear the console or not</param>
    public void Run(string displayMessage = "", bool clearConsole = true) {
        //Make sure that there are menu options
        if (_options.Count < 1) {
                Console.WriteLine("No menu options found");
                return;
            }

        while (true) {
            if (clearConsole) {Console.Clear();}
            if (displayMessage != "") { Console.WriteLine(displayMessage); }

            // Create the menu from the list of options
            for (int i = 0; i < _options.Count; i++) {
                Console.WriteLine($"    {i + 1}. {_options[i].Name}");
            }

            //Get user input and run the associated function
            Console.WriteLine("\nPlease choose an option:");
            Console.Write("> ");

            //Make sure the user input is valid
            string strChoice = Console.ReadLine();
            if (int.TryParse(strChoice, out int choice)
                && choice > 0 && choice <= _options.Count)
            {
                _options[choice - 1].Action();
                break;
            } else if (_options.Any(option => option.Name.Trim().ToLower() == strChoice.Trim().ToLower())) {
                MenuOption optionToExecute = _options.FirstOrDefault(option => option.Name.Trim().ToLower() == strChoice.Trim().ToLower());
                optionToExecute.Action();
                break;
            } else {
                Console.WriteLine($"{strChoice} is not a valid option.");
                Console.Write("Press enter to continue");
                Console.ReadLine();
                continue;
            }
        }
    }
}
