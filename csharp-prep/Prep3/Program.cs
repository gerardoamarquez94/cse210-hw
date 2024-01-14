using System;

class GuessMyNumberGame
{
    static void Main()
    {
        bool playAgain = true;

        while (playAgain)
        {
            // Generate a random magic number
            Random random = new Random();
            int magicNumber = random.Next(1, 101);
            int userGuess = 0;
            int guessCount = 0;

            // Loop until the user guesses the magic number
            while (userGuess != magicNumber)
            {
                Console.Write("What is your guess? ");
                userGuess = int.Parse(Console.ReadLine());
                guessCount++;

                if (userGuess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else if (userGuess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else
                {
                    Console.WriteLine($"You guessed it in {guessCount} guesses!");
                }
            }

            // Ask the user if they want to play again
            Console.Write("Do you want to play again? (yes/no): ");
            string response = Console.ReadLine().Trim().ToLower();
            playAgain = response == "yes";
        }

        Console.WriteLine("Thank you for playing!");
    }
}
