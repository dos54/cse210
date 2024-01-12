using System;

class Program
{
    static void Main(string[] args)
    {
        //Have the user enter numbers, which will be added to a list of numbers.
        //The sum, average, and largest number will be calculated.
        List<int> numbers = new();
        
        Console.WriteLine("Enter a list of numbers, type 0 when finished");
        int userNumber;
        do {
            Console.Write("Enter a number: ");
            string inputNumber = Console.ReadLine();
            userNumber = int.Parse(inputNumber);

            if (userNumber != 0) {numbers.Add(userNumber);}
        } while (userNumber != 0);

        int largestNumber = 0;
        int sumOfNumbers = 0;
        float average = 0;
        foreach (int number in numbers)
        {
            if (number > largestNumber) {largestNumber = number;}
            sumOfNumbers += number;
        }
        average = (float)sumOfNumbers / numbers.Count;

        Console.WriteLine($"The sum is: {sumOfNumbers}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {largestNumber}");
    }
}