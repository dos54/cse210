using System;

public class ReflectionActivity : Activity {
    private List<string> _questions;
    private List<string> _prompts;
    
    //Constructors

    //Getters & setters
    public List<string> Questions {
        get { return _questions; }
        set { _questions = value; }
    }
    public List<string> Prompts {
        get { return _prompts; }
        set { _prompts = value; }
    }
    
    //Methods
    public string GetRandomQuestion() {
        return RandomGenerator(_questions);
    }

    public string GetRandomPrompt() {
        return RandomGenerator(_prompts);
    }

    public void DisplayPrompt(string prompt) {
        Console.WriteLine($"--- {prompt} ---\n");
    }
    
    public void DisplayQuestion(string question) {
        Console.WriteLine($"> {question} ");
    }
    public void Run() {
        Console.Clear();
        DisplayStartMessage();
        DisplayDescription();
        UserSetsDuration();
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);

        Console.WriteLine(StartMessage);
        string prompt = GetRandomPrompt();
        DisplayPrompt(prompt);
        
        Console.WriteLine("\nWhen you have something in mind, press enter to continue");
        Console.ReadLine();

        Console.WriteLine("Now ponder on each of the following questions as they related to this experience:");
        Console.Write("You may begin in: ");
        DisplayTimer(5);
        Console.Clear();

        DisplayPrompt(prompt);
        int num_questions = 3;
        for (int i = 0; i < num_questions; i++) {
            string question = GetRandomQuestion();
            DisplayQuestion(question);
            ShowSpinner((int)Math.Round(Duration / (decimal)num_questions));
        }
        Console.WriteLine("\nWell done!\n");
        ShowSpinner(5);

        DisplayEndMessage();
        ShowSpinner(5);
    }
}