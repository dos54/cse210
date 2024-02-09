using System;

public class ChecklistGoal : Goal
{
    private int _timesCompleted;
    public int TimesCompleted
    {
        get {return _timesCompleted;}
        set {_timesCompleted = value;}
    }

    private int _target;
    public int Target
    {
        get {return _target;}
        set {_target = value;}
    }

    private int _bonusPoints;
    public int BonusPoints
    {
        get {return _bonusPoints;}
        set {_bonusPoints = value;}
    }

    public ChecklistGoal()
    {
        Type = "ChecklistGoal";
    }

    public ChecklistGoal(string name, string description, int pointsValue, int target, int bonusPoints) : base(name, description, pointsValue)
    {
        Type = "ChecklistGoal";
        _timesCompleted = 0;
        _target = target;
        _bonusPoints = bonusPoints;
    }

    public override void RecordEvent()
    {
        _timesCompleted++;
        if (TimesCompleted >= Target)
        {
            IsComplete = true;
        }
    }

    public override string GetDetailsString()
    {
        return $"{Name} ({Description}) -- Progress: {TimesCompleted}/{Target}";
    }
}