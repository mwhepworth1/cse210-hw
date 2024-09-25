using System;

class Program
{
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int squared = squaredNumber(number);
        DisplayResult(name, squared);
    }
    static void DisplayWelcome() {
        Console.WriteLine("Welcome to the Program!");
    }
    static string PromptUserName() {
        Console.WriteLine("What is your name?");
        return Console.ReadLine();
    }
    static int PromptUserNumber() {
        Console.WriteLine("Enter your favorite number:");
        return int.Parse(Console.ReadLine());
    }
    static int squaredNumber(int number) {
        return number * number;
    }
    static void DisplayResult(string name, int squaredNumber) {
        Console.WriteLine($"Hello {name}, your square number is {squaredNumber}");
    }
}