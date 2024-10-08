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

    // public string CreateEntry(Prompt, Response, Date)
    // {
    //     string entry = "";
    //     entry = ($"Date: {Date} -- Prompt: {Prompt}\n{Response}");
    //     return  entry;

    // }

}