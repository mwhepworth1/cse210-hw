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
        
        FileHandler file = new();

        bool success = file.Write(filename, entries);
        if (success) {
            Console.WriteLine("File saved successfully.");
        } else {
            Console.WriteLine("Whoops, something went wrong. The file was not saved.");
        }
    }
    public void LoadFromFile()
    {
        Console.WriteLine("What file would you like to load?");
        string filename = Console.ReadLine();
        
        FileHandler file = new();
        entries = file.Read(filename);
    }
}