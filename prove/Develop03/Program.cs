using System;

class Program
{
    static void Main(string[] args)
    {
        Scripture scripture = new();
        bool isFinished;
        string res;
    
        do 
        {
            scripture.Display();
            Console.WriteLine("\nEnter 'quit' or 'q' to quit, or press enter to hide more words.");
            res = Console.ReadLine();
            isFinished = scripture.AreAllWordsHidden();

        } while (res != "quit" && res != "q" && !isFinished);
    }
}