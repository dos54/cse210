using System;

public abstract class Goal
{
    // Members
    public string Type {get; set;}
    protected string _name = "";
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    protected string _description = "";
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    protected int _pointsValue = 0;
    public int PointsValue
    {
        get { return _pointsValue; }
        set { _pointsValue = value; }
    }

    protected bool _isComplete = false;
    public virtual bool IsComplete
    {
        get { return _isComplete; }
        set { _isComplete = value; }
    }

    public Goal(string name, string description, int pointsValue)
    {
        _name = name;
        _description = description;
        _pointsValue = pointsValue;
    }

    public Goal()
    {
        
    }

    // Abstract methods
    
    /// <summary>
    /// Returns the goal name as a string 
    /// </summary>
    /// <returns></returns>
    public abstract string GetDetailsString();
    

    /// <summary>
    /// Record when an event happens 
    /// </summary>
    public abstract void RecordEvent();

    


}