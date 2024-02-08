using System;

public class Player
{
    private string _playerDataFile;
    public string PlayerDataFile
    {
        get {return _playerDataFile;}
    }
    
    private int _score = 0;
    private string _name = "";
    private List<Goal> _goals = new();

    public Player() 
    {
        _playerDataFile = $"{_name}_data.json";
    }

    public int Score
    {
        get {return _score;}
        set {_score = value;}
    }

    public string Name 
    {
        get {return _name;}
        set {_name = value;}
    }

    public List<Goal> Goals
    {
        get {return _goals;}
        set {_goals = value;}
    }


}