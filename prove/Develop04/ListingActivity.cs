using System;

public class ListingActivity : Activity {
    private List<string> _prompts;
    private int _count;

    public List<string> Prompts {
        get {return _prompts;}
        set {_prompts = value;}
    }
    public int Count {
        get {return _count;}
        set {_count = value;}
    }
    public string GetRandomPrompt() {
        return RandomGenerator(Prompts);
    }
    public static void DisplayPrompt(string prompt) {
        Console.WriteLine($"--- {prompt} ---");
    }
    public List<string> GetListFromUser() {
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(Duration);
        DateTime currentTime;

        List<string> userList = new();
        do {
            currentTime = DateTime.Now;
            Console.Write("> ");
            userList.Add(Console.ReadLine());
        } while (currentTime < endTime);

        return userList;
    }
    public void Run() {
        Console.Clear();
        DisplayStartMessage();
        DisplayDescription();
        UserSetsDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        Console.WriteLine("List as many responses as you can to the following prompt: ");
        string prompt = GetRandomPrompt();
        DisplayPrompt(prompt);
        Console.WriteLine("\nYou may begin in: ");
        DisplayTimer(5);
        List<string> userList = GetListFromUser();
        Console.WriteLine($"You listed {userList.Count} items!\n");
        Console.WriteLine("Well done!\n");
        ShowSpinner(5);
        DisplayEndMessage();
        ShowSpinner(5);
    }
}