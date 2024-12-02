using System;
using System.Collections;
using System.Transactions;
/*

Instructions for installing and running this app:
    1. Install the Newtonsoft.Json NuGet package.
        "dotnet add package Newtonsoft.Json"
    2. Install the Microsoft.Toolkit.Uwp.Notifications NuGet package.
        "dotnet add package Microsoft.Toolkit.Uwp.Notifications"

*/

class Program
{
    private static List<Assignment> assignments = new();
    static void Main(string[] args)
    {
        string res;
        do 
        {
            Console.Clear();
            Console.WriteLine("Canvas Connect");
            Console.WriteLine("Please choose one of the following options:");
            Console.WriteLine("    1. Link Account");
            Console.WriteLine("    2. View Calendar");
            Console.WriteLine("    3. Settings");
            Console.WriteLine("    4. Quit");

            res = Console.ReadLine();

            switch (res)
            {
                case "1":
                    LinkAccount();
                    break;
                case "2":
                    Console.Clear();
                    Calendar calendar = new Calendar(DateTime.Now, assignments); // Reassigning cal item if date change takes place.
                    calendar.Display();
                    break;
                case "3":
                    Console.WriteLine("Settings");
                    break;
            }
        } while (res != "q" || res != "quit" || res != "4");
    }
    private static void LinkAccount()
    {
        Console.Clear();
        string[] lines = [  "********************************************************************",
                            "To link your account, you will need to enter your Canvas API key.",
                            "To obtain your key, please follow the instructions below:",
                            "    1. Log in to your Canvas account.",
                            "    2. Click on Account in the left-hand menu.",
                            "    3. Click on Settings.",
                            "    4. Scroll down to the Approved Integrations section.",
                            "    5. Click on the New Access Token button.",
                            "    6. Enter a name for your token and click Generate Token.",
                            "    7. Copy the token and paste it below.",
                            "********************************************************************"];
        foreach (string line in lines)
        {
            Console.WriteLine(line);
        }
        Console.Write("Paste your Canvas API key here: ");
        string key = Console.ReadLine();
        // look to see if the key is valid.
        // save key to json file.
    }
}

/*
Final Project Idea: Canvas API Integration

Program.cs (1/9)
Assignment.cs (2/9)
- Name
- Description
- Due Date
- Points
- Submission Type
- Grade
Announcement.cs (3/9)
- Title
- Message
- Date
- Author
Course.cs (4/9)
- Name
- Code
- Instructor
- Term
- Semester
Toast.cs (5/9)
- Message
- Type
- Date
- Course
Message.cs (6/9)
- Title
- Body
- Date
- Author
- Course
Calendar.cs (7/9)
- Date
- Assignment
- Announcement
- Course

*/