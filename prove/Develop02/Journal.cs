public class Journal
{
    // Entries list
    private List<Entry> entries = new();

    public void AddEntry()
    {
        PromptManager promptManager = new();
        string prompt = promptManager.GetRandomPrompt();
        
        Entry entry = new();
        entry.CreateEntry(prompt);      
        
        entries.Add(entry);        
    }
    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"{entry.Date}: {entry.Prompt} >");
            Console.WriteLine(entry.Response);
        }
    }
    public void SaveToFile()
    {
        Console.WriteLine("What would you like to name this file?");
        string filename = Console.ReadLine();
        if (!filename.EndsWith(".txt"))
        {
            filename += ".txt"; // Add the .txt extension if it's not already there
        }
        using (StreamWriter writer = new(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Date}: {entry.Prompt} >");
                writer.WriteLine(entry.Response);
            }
        }
    }
    public void LoadFromFile()
    {
        Console.WriteLine("What file would you like to load?");
        string filename = Console.ReadLine();
        if (!filename.EndsWith(".txt"))
        {
            filename += ".txt"; // Add the .txt extension if it's not already there
        }
        if (File.Exists(filename))
        {
            using (StreamReader reader = new(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(':'); // Splits the line into parts at the colon: Date and Prompt
                    if (parts.Length == 2) // If the split was successful, there should be two parts
                    {
                        DateTime date = DateTime.Parse(parts[0]); // Parse the date from the first part
                        string prompt = parts[1].TrimEnd(' ', '>'); // Trim whitespace and the > from the end of the prompt
                        string response = reader.ReadLine(); // Read the next line as the response

                        Entry entry = new Entry
                        {
                            Date = date,
                            Prompt = prompt,
                            Response = response
                        };

                        entries.Add(entry); // Add the new entry to the list
                    }
                    
                } 
            }
        }
        else
        {
            Console.WriteLine("Whoops, the file was not found.");
        }
    }
}