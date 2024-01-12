using System;
using System.Data;

class Program
{
    static void Main(string[] args)
    {
        //The main do-while loop. Will loop until playAgain is false (false by default).
        //All the code for the game goes in this loop
        bool playAgain = false;
        do {
            //Generate a random number and initialize the guess int
            Random randomGenerator = new();
            int magicNumber = randomGenerator.Next(1, 100);
            int timesGuessed = 0;
            int guess;

            do {
                timesGuessed++;

                Console.Write("What is your guess? ");
                string strGuess = Console.ReadLine();
                guess = int.Parse(strGuess);

                if (guess == magicNumber) 
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It only took you {timesGuessed} tries.");
                    
                    Console.Write("Would you like to play again? (yes/no) ");
                    string strPlayAgain = Console.ReadLine().Trim().ToLower();
                    if (strPlayAgain == "yes" || strPlayAgain == "y")
                    {
                        playAgain = true;
                    }
                    else
                    {
                        playAgain = false;
                    }
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine("Lower");
                }
            } while (guess != magicNumber);
        } while (playAgain);

    }
}