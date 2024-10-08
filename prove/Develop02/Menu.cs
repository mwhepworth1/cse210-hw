using System;

class Menu
{
    private Journal journal = new();
    public void DisplayOptions()
    {
        Console.WriteLine("Select an option:");
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
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveToFile();
                    break;
                case "4":
                    journal.LoadFromFile();
                    break;
                case "5":
                    quit = true;
                    Console.WriteLine("Shutting down the Journal app. Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid input. Please try again.");
                    break;
            }
        }
    }
}