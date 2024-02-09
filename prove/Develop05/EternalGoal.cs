using System;

public class EternalGoal : Goal
{

    public EternalGoal()
    {
        Type = "EternalGoal";
    }

    public EternalGoal(string name, string description, int pointsValue) : base(name, description, pointsValue)
    {
        Type = "EternalGoal";
    }


    public override void RecordEvent()
    {
        IsComplete = false;
    }

    public override string GetDetailsString()
    {
        return $"{Name} ({Description})";
    }

}