using System;
using System.Security.AccessControl;

public class Activity {
    private string _startMessage;
    private string _endMessage;
    private int _duration;
    private string _description;
    private string _activityName;

    //Constructors
    public Activity() {
        _activityName = "Activity";
        _description = "Description";
        _duration = 10;
    }

    public Activity(string activityName, string description) {
        _activityName = activityName;
        _description = description;
        _duration = 10;
    }
    public Activity(string activityName, string description, int duration) {
        _activityName = activityName;
        _description = description;
        _duration = duration;
    }

    //Getters and setters
    public string StartMessage
    {
        get { return _startMessage; }
        set { _startMessage = value; }
    }

    public string EndMessage
    {
        get { return _endMessage; }
        set { _endMessage = value; }
    }

    public int Duration
    {
        get { return _duration; }
        set
        {
            if (value >= 0)
                _duration = value;
            else
                throw new ArgumentException("Duration must be non-negative");
        }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public string ActivityName
    {
        get { return _activityName; }
        set { _activityName = value; }
    }

    //Class methods
    protected string RandomGenerator(List<string> strings) {
        Random random = new();
        return strings[random.Next(strings.Count)];
    }

    public void UserSetsDuration() {
        while (true) {
            Console.WriteLine("How long, in seconds, would you like for your session to last? ");
            Console.Write("> ");
            if (int.TryParse(Console.ReadLine(), out int timeSeconds)
            && timeSeconds > 0) {
                Duration = timeSeconds;
                return;
            } else {
                Console.WriteLine("Invalid time. Please enter a valid time");
                Console.WriteLine("Press enter to continue");
                Console.ReadLine();
                continue;
            }
        }
    }
    public void DisplayStartMessage() {
        Console.WriteLine($"Welcome to {_activityName}\n");
    }
    public void DisplayEndMessage() {
        Console.WriteLine($"You have completed {_duration} seconds of {_activityName}.\n");
    }
    public void DisplayDescription() {
        Console.WriteLine(_description + "\n");
    }
    public static void DisplayTimer(int seconds) {
        Console.CursorVisible = false;
        for (int i = seconds; i > 0; i--) {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.CursorVisible = true;
    }
    public static void ShowSpinner(int seconds) {
        List<string> spinnerAnimation = new() {"-", "\\", "|", "/", "-", "\\", "|", "/"};
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        Console.CursorVisible = false;
        while (true) {
            foreach (string frame in spinnerAnimation) {
                if (DateTime.Now > endTime) {
                        Console.CursorVisible = true;
                        return;
                    }
                Console.Write(frame);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }
    }
}