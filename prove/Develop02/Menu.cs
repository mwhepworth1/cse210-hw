using System;

class Menu
{
    private Journal _journal = new();
    public void DisplayOptions()
    {
        Console.WriteLine("\n\nSelect an option:");
        Console.WriteLine("1. Write");
        Console.WriteLine("2. Display");
        Console.WriteLine("3. Save");
        Console.WriteLine("4. Load");
        Console.WriteLine("5. Quit");
    }
    
    public void HandleSelection() 
    {
        bool quit = false;
        
        while (!quit)
        {
            DisplayOptions();
            string input = Console.ReadLine();

            switch(input) // Switch/case is is used to select the appropriate action based on the user's input
            // The input is a string, so we can use a string in the case statement and refrain from clunky if/else statements.
            {
                case "1":
                    AddSpace();
                    _journal.AddEntry();
                    break;
                case "2":
                    AddSpace();
                    _journal.DisplayEntries();
                    break;
                case "3":
                    AddSpace();
                    _journal.SaveToFile();
                    break;
                case "4":
                    AddSpace();
                    _journal.LoadFromFile();
                    break;
                case "5":
                    AddSpace();
                    quit = true;
                    Console.WriteLine("Shutting down the Journal app. Goodbye!");
                    break;
                default:
                    AddSpace();
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }
    private static void AddSpace()
    {
        Console.WriteLine("\n");
    }
}