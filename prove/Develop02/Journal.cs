public class Journal
{
    // Entries list
    private List<Entry> _entries = new();

    public void AddEntry()
    {
        PromptManager promptManager = new();
        string prompt = promptManager.GetRandomPrompt();
        
        Entry entry = new();
        entry.CreateEntry(prompt);      
        
        _entries.Add(entry);        
    }
    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine($"{entry._Date}: {entry._Prompt} >");
            Console.WriteLine(entry._Response);
        }
    }
    public void SaveToFile()
    {
        Console.WriteLine("What would you like to name this file?");
        string filename = Console.ReadLine();
        
        FileHandler file = new();

        bool success = file.Write(filename, _entries);
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
        _entries = file.Read(filename);
    }
}