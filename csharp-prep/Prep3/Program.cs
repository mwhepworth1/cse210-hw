using System;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Guess My Number Game!");
        Console.WriteLine("I'm thinking of a number between 1 and 100.");
        
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);

        string guess;
        int userGuess;

        int totalGuesses = 0;
        
        do 
        {
            totalGuesses++;
            Console.WriteLine("What is your guess?");
            guess = Console.ReadLine();
            userGuess = int.Parse(guess);

            if (userGuess == number)
            {
                Console.WriteLine("Congratulations! You guessed the magic number in " + totalGuesses + " guesses!");
            }
            else if (userGuess < number)
            {
                Console.WriteLine("Guess higher!");
            }
            else
            {
                Console.WriteLine("Guess lower!");
            }
        } while (number != userGuess);

    }
}