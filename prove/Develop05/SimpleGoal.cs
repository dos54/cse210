using System;

public class SimpleGoal : Goal
{

    public SimpleGoal()
    {
        Type = "SimpleGoal";
    }

    public SimpleGoal(string name, string description, int pointsValue) : base(name, description, pointsValue)
    {
        Type = "SimpleGoal";
    }

    public override void RecordEvent()
    {
        IsComplete = true;
    }

    public override string GetDetailsString()
    {
        return $"{Name} ({Description})";
    }
}