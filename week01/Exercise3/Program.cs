using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new();
        int magicNumber = random.Next(1, 101); // Generates a random number between 1 and 100
        int guess;
        int tries = 0;
        string continueGuessing = "yes";

        Console.WriteLine("Welcome to the Number Guessing Game!");
        Console.WriteLine("I have selected a magic number between 1 and 100. Try to guess it!");

        do
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            tries++;

            if (guess == magicNumber)
            {
                Console.WriteLine("You guessed it!");
                Console.WriteLine($"It took you {tries} tries.");
                Console.Write("Do you want to play again? (yes/no): ");

                magicNumber = random.Next(1, 101); // Generates a new random number for the next game
                tries = 0; // Reset tries for the new game
                guess = 0; // Reset guess for the new game
                continueGuessing = Console.ReadLine();
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("Higher");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("Lower");
            }
            else
            {
                Console.WriteLine("Sorry, that is not correct.");
            }   
        } while (guess != magicNumber && continueGuessing.ToLower().Equals("yes"));
    }
}