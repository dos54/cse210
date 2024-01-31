using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment mathAssignment = new("Steven", "Fractions", "7.3", "8-19");
        WritingAssignment writingAssignment = new("Steven", "European History", "The Causes of World Ward II");

        Console.WriteLine(mathAssignment.GetSummary());
        Console.WriteLine(mathAssignment.GetHomeworkList());
        Console.WriteLine(writingAssignment.GetSummary());
        Console.WriteLine(writingAssignment.GetWritingInformation());
    }
}