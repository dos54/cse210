using System;

class Program
{
    static void Main(string[] args)
    {
        //Get first and last names
        Console.Write("What is your first name? ");
        string firstName = Console.ReadLine();
        Console.Write("What is your last name? ");
        string lastName = Console.ReadLine();

        //Create an extra space
        Console.WriteLine();
        //Output last-name, first-name last-name
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}