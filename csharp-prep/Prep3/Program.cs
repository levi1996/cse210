using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain;
        
        do
        {
            // Generate a random magic number between 1 and 100
            Random randomGenerator = new Random();
            int magicNumber = randomGenerator.Next(1, 101);

            int guess = 0;
            int attempts = 0; // Counter for attempts

            Console.WriteLine("Welcome to the Guess My Number Game!");

            // Loop for the guessing game
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");

                // Read user input and convert to an integer
                try
                {
                    guess = int.Parse(Console.ReadLine());
                    attempts++; // Increment attempts

                    // Provide feedback on the guess
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
                        Console.WriteLine($"You guessed it! It took you {attempts} attempts.");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Please enter a valid number.");
                }
            }

            // Ask if the user wants to play again
            Console.Write("Do you want to play again? (yes/no): ");
            playAgain = Console.ReadLine().ToLower();

        } while (playAgain == "yes");

        Console.WriteLine("Thank you for playing! Goodbye!");
    }
}
