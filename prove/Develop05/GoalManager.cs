using System;
using System.Diagnostics.Contracts;
using System.Text.Json;

public class GoalManager
{
    private int _score;
    private List<Goal> _goals;

    public int Score
    {
        get {return _score;}
        set {_score = value;}
    }
    public List<Goal> Goals
    {
        get {return _goals;}
        set {_goals = value;}
    }
    public GoalManager()
    {
        _goals = new();
    }


    public void Start()
    {
        Menu menu = new();
        menu.AddOption("Create New Goal", CreateGoal);
        menu.AddOption("List Goals", DisplayGoals);
        menu.AddOption("Save Goals", SaveDataPrompt);
        menu.AddOption("Load Goals", LoadDataPrompt);
        
        while(true)
        {
            menu.Run("\nMenu Options:", clearConsole: false);
        }
    }

    public void DisplayPlayerInformation()
    {
        
    }

    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"    {i}. {_goals[i].Name}");
        }
    }

    public void ListGoalDetails()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"    {i}. {_goals[i].Description}");
        }

    }

    public void CreateGoal()
    {
        Console.WriteLine("The types of goals are:");
        Console.WriteLine(" 1. Simple Goal");
        Console.WriteLine(" 2. Eternal Goal");
        Console.WriteLine(" 3. Checklist Goal");

        Console.Write("Which type of goal would you like to create? ");

        _ = int.TryParse(Console.ReadLine(), out int goalType);
        Console.Write("What is the name of your goal? ");
        string goalName = Console.ReadLine();
        Console.Write("What is a short description of your goal? ");
        string goalDescription = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        _ = int.TryParse(Console.ReadLine(), out int points);
        
        switch (goalType)
        {
            case 1:
                _goals.Add(new SimpleGoal(goalName, goalDescription, points));
                break;

            case 2:
                _goals.Add(new EternalGoal(goalName, goalDescription, points));
                break;

            case 3:
                Console.Write("How many times would you like to do this goal? ");
                _ = int.TryParse(Console.ReadLine(), out int goalTarget);
                Console.Write("How many bonus points will be rewarded upon completion? ");
                _ = int.TryParse(Console.ReadLine(), out int bonusPoints);
                _goals.Add(new ChecklistGoal(goalName, goalDescription, points, goalTarget, bonusPoints));
                break;

            default:
                Console.WriteLine($"Invalid option {goalType}");
                break;
        }

    }

    public void RecordEvent()
    {

    }

    public void DisplayGoals() 
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"    {i + 1}. {_goals[i].GetStringRepresentation()}");
        }
    }

    public void SaveDataPrompt()
    {
        Console.Write("What is the file name for the goals file? ");
        string fileName = Console.ReadLine();
        Save(fileName);
    }

    public void LoadDataPrompt()
    {
        Console.Write("What is the file name for the goals file? ");
        string fileName = Console.ReadLine();
        Load(fileName);
    }

    public void Save(string dataFile)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        string jsonString = JsonSerializer.Serialize(this, options);
        File.WriteAllText(dataFile, jsonString);
    }

    public void Load(string dataFile)
    {
        var jsonString = File.ReadAllText(dataFile);
        
        GoalManager data = JsonSerializer.Deserialize<GoalManager>(jsonString);
        Score = data.Score;
        Goals = data.Goals;
    }


}