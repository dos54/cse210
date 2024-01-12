using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage? ");
        string gradePercentInput = Console.ReadLine();
        int gradePercent = int.Parse(gradePercentInput);

        string letterGrade= "F";
        if (gradePercent >= 90)
        {
            letterGrade = "A";
        }
        else if (gradePercent < 90 && gradePercent >= 80)
        {
            letterGrade = "B";
        }
        else if (gradePercent < 80 && gradePercent >= 70)
        {
            letterGrade = "C";
        }
        else if (gradePercent < 70 && gradePercent >= 60)
        {
            letterGrade = "D";
        }

        Console.WriteLine($"Your letter grade is {letterGrade}");
        
        if (gradePercent >= 70)
        {
            Console.WriteLine("Congratulations, you passed!");
        }
        else
        {
            Console.WriteLine("I'm sorry, but you failed. Please retake this class!");
        }

    }
}