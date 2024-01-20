using System;

public class PromptGenerator {
    public List<string> _prompts = new()
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",        
        "Describe a significant learning experience you had this week and its impact on your perspective",
        "Reflect on a challenging situation you recently faced and how you resolved it",
        "Discuss a new skill or knowledge area you are interested in exploring, and why it intrigues you"
    };

    //Get a new prompt for a journal entry
    public string GeneratePrompt() {
        Random random = new();
        int index = random.Next(_prompts.Count);
        string prompt = _prompts[index];
        
        return prompt;
    }
}