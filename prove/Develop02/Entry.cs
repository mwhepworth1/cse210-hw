using System;

public class Entry
{
    public string Prompt;
    public string Response;
    public DateTime Date;
    public void CreateEntry(string prompt)
    {
        Prompt = prompt;
        Console.WriteLine(prompt);
        Response = Console.ReadLine();
        Date = DateTime.Now;
    }
}