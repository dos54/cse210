using System;

public class BreathingActivity : Activity {
    public BreathingActivity() {

    }
    public void Run() {
        while (true) {
            Console.Clear();
            DisplayStartMessage();
            DisplayDescription();
            UserSetsDuration();
            Console.Clear();
            Console.WriteLine("Get ready...");
            ShowSpinner(5);
            int repeats = (int)Math.Ceiling(Duration / 10.0f);
            for (int i = repeats; i > 0; i--) {
                Console.WriteLine($"\nBreathe in..." );
                DisplayTimer(4);
                Console.WriteLine("Now breathe out... ");
                DisplayTimer(6);
            }
            Console.WriteLine();
            Console.WriteLine("Well done!!\n");
            ShowSpinner(5);
            DisplayEndMessage();
            return;
        }
    }
}