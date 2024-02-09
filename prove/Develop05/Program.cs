using System;

class Program
{
    // To exceed requirements I did three things:
    // 1. I added a leveling system, where every time your score increases on a curve you reach a new level.
    // 2. The menu displays your current level as well as the amount of points needed to reach the next level.
    // 3. I chose to save my data in a JSON file, as I felt that it was a format that I am more likely to use in the future.
    //      To make it function properly, I had to implement a system to correctly figure out the type of object before
    //      adding it to the Goal list. This take way more time than I would like to admit, and I honestly wish that I had just
    //      saved it in a .txt file with a custom format now. Oh well! 
    static void Main(string[] args)
    {
        new GoalManager().Start();
    }
}