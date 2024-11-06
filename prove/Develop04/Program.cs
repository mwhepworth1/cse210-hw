using System;

class Program
{
    static void Main(string[] args)
    {
        bool stop = false;
        do
        {
            Console.Clear();
            Console.WriteLine("Please choose one of the following mindfulness activities:");
            Console.WriteLine("\t1. Breathing");
            Console.WriteLine("\t2. Reflection");
            Console.WriteLine("\t3. Listing");
            Console.WriteLine("To quit, type 'q' or 'quit'.\n");
            Console.Write("What is your choice? ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Breathing breathing = new();
                    breathing.Start();
                    break;
                case "2":
                    Reflection reflection = new();
                    reflection.Start();
                    break;
                case "3":
                    Listing listing = new();
                    listing.Start();
                    break;
                case "q":
                    stop = true;
                    break;
                case "quit":
                    stop = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        } while (stop == false);
    }
    private static void ClearCurrentConsoleLine()
    {
        int currentLineCursor = Console.CursorTop;
        Console.SetCursorPosition(0, currentLineCursor);
        Console.Write(new string(' ', Console.WindowWidth));
        Console.SetCursorPosition(0, currentLineCursor);
    }
}