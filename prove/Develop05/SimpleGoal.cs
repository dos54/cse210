using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int pointsValue) : base(name, description, pointsValue)
    {

    }

    public override void RecordEvent()
    {
        IsComplete = true;
    }

    public override string GetStringRepresentation()
    {
        return $"{Name} ({Description})";
    }
}