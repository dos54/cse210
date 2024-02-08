using System;

public class EternalGoal : Goal
{

    public EternalGoal(string name, string description, int pointsValue) : base(name, description, pointsValue)
    {

    }


    public override void RecordEvent()
    {
        IsComplete = false;
    }

    public override string GetStringRepresentation()
    {
        return $"{Name} {Description}";
    }

}