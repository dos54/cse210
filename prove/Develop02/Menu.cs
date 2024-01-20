using System;

public class Menu {
    
    public static void Display() 
    {
        string strChoice;
        int choice;
        do
        {
            Console.WriteLine("Welcome to the Journal program!");
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            strChoice = Console.ReadLine();
            choice = int.Parse(strChoice);
            switch (choice) {
                case 1:
                    break;
                default:
                    Console.WriteLine($"{choice} is not a valid option.");
                    break;
            }
        } while (choice != 5);
        
    }
}