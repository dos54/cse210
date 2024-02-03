using System;

// To exceed requirements I made a Menu and a MenuOptions classes to handle console menus. 
// In the Menu class I added functionality to allow users to select an option by either typing the number listed or the title of the option.
// I also used Lambda functions and other things throughout the program to make the program more flexible.
// For many of my Getters and Setters I used C#'s built in notation for getters and setters, using 
// get {function;} and 
// set {function;}
class Program
{
    static void Main(string[] args)
    {
        //Build the activities
        //------------------------

        //Breathing Activity
        //------------------------
        BreathingActivity breathingActivity = new()
        {
            ActivityName = "Breathing Activity",
            Description = "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing."
        };

        //Reflection activity
        //------------------------
        ReflectionActivity reflectionActivity = new()
        {
            ActivityName = "Reflection Activity",
            Description = "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.",
            Prompts = new List<string> 
            {
                "Reflect on a time when you faced a significant challenge. What was the situation, and how did you overcome it?",
                "Think about a moment when you experienced failure. What happened, and what did you learn from that experience?",
                "Recall a time when you had to make a difficult decision. What made it challenging, and how did you ultimately decide?",
                "Consider a moment when you felt particularly proud of an achievement. What did you accomplish, and why was it meaningful to you?",
                "Remember a time when you helped someone else. What was the situation, and how did it impact both of you?",
                "Think back to a moment when you received critical feedback. How did you react, and what changes did you make as a result?",
                "Reflect on a time when you stepped out of your comfort zone. What prompted you to do so, and what was the outcome?",
                "Recall an instance where you had to work closely with others. What was the task, and how did the group dynamics affect the result?",
                "Consider a time when you witnessed kindness or compassion. What happened, and how did it influence your views on empathy?",
                "Think about a moment of significant personal growth. What sparked this change, and how have you evolved since then?"
            },
            Questions = new List<string> 
            {
                "What was your initial expectation going into this experience, and how did the reality compare?",
                "What were the most challenging aspects of this experience for you, and why?",
                "Can you identify a moment that was particularly impactful or meaningful? What made it stand out?",
                "How did this experience change your perspective or understanding on a specific topic or in general?",
                "What skills or knowledge did you gain from this experience, and how do you plan to apply them in the future?",
                "Looking back, is there anything you would have done differently? Why or why not?",
                "Was there someone who significantly influenced your experience? How did they impact you?",
                "What were the key takeaways or lessons learned from this experience for you?",
                "How has this experience contributed to your personal or professional growth?",
                "In what ways do you think this experience will influence your decisions or actions in the future?"
            }
        };

        //Listing activity
        //------------------------
        ListingActivity listingActivity = new() 
        {
            ActivityName = "Listing Activity",
            Description = "This activiyu will help you reflect on the good things in your life by having you list as many things as you can in a certain area.",
            Prompts = new List<string> 
            {
            "What are your favorite hobbies, and why do you enjoy them?",
            "Can you list the books that have had a significant impact on your life? What did you learn from them?",
            "What are some skills you'd like to learn or improve? Why are those particular skills important to you?",
            "Who are people that inspire you the most? In what ways have they influenced your life or aspirations?",
            "What are your favorite ways to relax and unwind after a stressful day? How do they help you recharge?",
            "What destinations are on your travel bucket list, and what attracts you to those places?",
            "What are the most memorable experiences you've had while traveling? Why do they stand out to you?",
            "What are some career goals you have for the next five years? How do you plan to achieve them?",
            "What are your favorite cuisines or dishes, and what do you like about them?",
            "What are some challenges you've faced in life, and how did you overcome them? What did those experiences teach you?"
            }
        };

        //Build the menu
        //------------------------
        Menu menu = new();
        menu.AddOption("Start Breathing Activity", breathingActivity.Run);
        menu.AddOption("Start Reflection Activity", reflectionActivity.Run);
        menu.AddOption("Start Listing Activity", listingActivity.Run);

        menu.Run(displayMessage: "Menu Options:");
    }
}