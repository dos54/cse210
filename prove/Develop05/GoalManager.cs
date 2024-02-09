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
        menu.AddOption("Record Event", RecordEvent);
        
        while(true)
        {
            double currentLevel = Math.Floor(Math.Sqrt(Score));
            double nextLevelScore = Math.Pow(currentLevel + 1, 2);
            double pointsToLevelUp = nextLevelScore - Score;
            Console.WriteLine($"\nYou are level {currentLevel}.");
            Console.WriteLine($"You have {Score} points.");
            Console.WriteLine($"{pointsToLevelUp} points to level up");
            menu.Run("\nMenu Options:", clearConsole: false);
        }
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
        int startingScore = Score;
        Console.WriteLine("The goals are:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"    {i + 1}. {_goals[i].Name}");
        }
        Console.Write("What goal did you accomplish? ");
        string choice = Console.ReadLine();
        int choiceInt = int.Parse(choice);
        Goal goal = _goals[choiceInt - 1];
        goal.RecordEvent();
        Score += goal.PointsValue;
        if (goal is ChecklistGoal checklistGoal)
        {
            if (checklistGoal.TimesCompleted == checklistGoal.Target)
            {
                Score += checklistGoal.BonusPoints;
            }
        }

        Console.WriteLine($"Congratulations! You have earned {Score - startingScore} points!");
        Console.WriteLine($"You now have {Score} points.");
    }

    public void DisplayGoals() 
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            if (_goals[i].IsComplete)
            {
                Console.WriteLine($"[X] {i + 1}. {_goals[i].GetDetailsString()}");
            } else
            {
                Console.WriteLine($"[ ] {i + 1}. {_goals[i].GetDetailsString()}");
            }
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

        var goalsData = new List<object>();

        foreach (var goal in _goals)
        {
            switch (goal)
            {
                case ChecklistGoal checklistGoal:
                    goalsData.Add(new
                    {
                        Type = "ChecklistGoal",
                        checklistGoal.Name,
                        checklistGoal.Description,
                        checklistGoal.PointsValue,
                        checklistGoal.BonusPoints,
                        checklistGoal.IsComplete,
                        checklistGoal.TimesCompleted,
                        checklistGoal.Target
                    });
                    break;
                default:
                    goalsData.Add(goal);
                    break;
            }
        }

        var saveData = new
        {
            Score = Score,
            Goals = goalsData
        };

        string jsonString = JsonSerializer.Serialize(saveData, options);
        File.WriteAllText(dataFile, jsonString);
    }

    public void Load(string dataFile)
    {
        var jsonString = File.ReadAllText(dataFile);
        var tempObject = JsonSerializer.Deserialize<Dictionary<string, JsonElement>>(jsonString);
        
        var goals = JsonSerializer.Deserialize<List<JsonElement>>(tempObject["Goals"].GetRawText());
        List<string> goalsAsStrings = goals.Select(goal => goal.GetRawText()).ToList();

        Score = tempObject["Score"].GetInt32();
        Goals = new List<Goal>();

        var goalsJsonElement = tempObject["Goals"];

        foreach (var goalElement in goalsJsonElement.EnumerateArray())
        {
            string type = goalElement.GetProperty("Type").GetString();

            switch (type)
            {
                case "SimpleGoal":
                    Goals.Add(JsonSerializer.Deserialize<SimpleGoal>(goalElement.GetRawText()));
                    break;
                case "EternalGoal":
                    Goals.Add(JsonSerializer.Deserialize<EternalGoal>(goalElement.GetRawText()));
                    break;
                case "ChecklistGoal":
                    Goals.Add(JsonSerializer.Deserialize<ChecklistGoal>(goalElement.GetRawText()));
                    break;
            }
        }

    }


}