using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new();
        job1._jobTitle = "Software Engineer";
        job1._company = "Microsoft";
        job1._startYear = 2019;
        job1._endYear = 2022;

        Job job2 = new() {
            _jobTitle = "Manager",
            _company = "Apple",
            _startYear = 2022,
            _endYear = 2023
        };

        Resume myResume = new()
        {
            _name = "Juan Carlos",
        };

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}