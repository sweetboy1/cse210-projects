using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;

        do
        {
            // Generate a random number from 1 to 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = -1;
            int guessCount = 0;

            Console.WriteLine("Welcome to the Guess My Number game!");

            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                    Console.WriteLine($"It took you {guessCount} guesses.");
                }
            }

            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("Thanks for playing! Goodbye.");
    }
}
