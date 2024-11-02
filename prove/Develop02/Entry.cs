using System;

public class Entry
{
    public string _Prompt;
    public string _Response;
    public DateTime _Date;
    public void CreateEntry(string prompt)
    {
        _Prompt = prompt;
        Console.WriteLine(prompt);
        _Response = Console.ReadLine();
        _Date = DateTime.Now;
    }
}