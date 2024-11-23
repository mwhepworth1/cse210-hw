using System.IO;
using System.Net;
using System.Runtime.CompilerServices;

class Program
{
    /*
    Above and Beyond: I added a TimedGoal that takes a deadline and awards prorated bonus
    points based on how quickly the goal was completed. The bonus points are capped at 300% of the original points awarded.
    */

    private static List<Goal> goals = new(); // Can handle any goal type.
    private static int _totalPoints = 0;
    static void Main(string[] args)
    {
        string res = "";
        do
        {
            Console.Clear();
            Console.WriteLine($"You have {_totalPoints} points.\n");
            Console.WriteLine("Menu Options:");
            Console.WriteLine("    1. Create New Goal");
            Console.WriteLine("    2. List Goals");
            Console.WriteLine("    3. Save Goals");
            Console.WriteLine("    4. Load Goals");
            Console.WriteLine("    5. Record Event");
            Console.WriteLine("    6. Exit");
            res = Console.ReadLine();
            switch (res)
            {
                case "1":
                    CreateAGoal();
                    break;
                case "2":
                    ListGoals();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
            }
        } while (res != "6" && res != "exit" && res != "quit");
    }
    private static void CreateAGoal()
    {
        Console.WriteLine("Select a goal:");
        Console.WriteLine("    1. Simple Goal");
        Console.WriteLine("    2. Eternal Goal");
        Console.WriteLine("    3. Checklist Goal");
        Console.WriteLine("    4. Timed Goal");
        Console.WriteLine("    5. Go Back");
        string res = Console.ReadLine();
        switch (res)
        {
            case "1":
                SimpleGoal();
                break;
            case "2":
                EternalGoal();
                break;
            case "3":
                ChecklistGoal();
                break;
            case "4":
                TimedGoal();
                break;
            case "5":
                break;
        }
    }
    private static void SimpleGoal()
    {
        Console.Write("What is the name of your goal? ");
        string title = Console.ReadLine();
        Console.Write("What is the description of your goal? ");
        string description = Console.ReadLine();
        Console.Write("How many points should you get for completing this goal? ");
        int pointsAwarded = int.Parse(Console.ReadLine());
        SimpleGoal simpleGoal = new(title, description, false, pointsAwarded);
        goals.Add(simpleGoal);
    }
    private static void EternalGoal() 
    {
        Console.Write("What is the name of your goal? ");
        string title = Console.ReadLine();
        Console.Write("What is the description of your goal? ");
        string description = Console.ReadLine();
        Console.Write("How many points should you get for completing this goal? ");
        int pointsAwarded = int.Parse(Console.ReadLine());
        EternalGoal eternalGoal = new(title, description, false, pointsAwarded);
        goals.Add(eternalGoal);
    }
    private static void ChecklistGoal() 
    {
        Console.Write("What is the name of your goal? ");
        string title = Console.ReadLine();
        Console.Write("What is the description of your goal? ");
        string description = Console.ReadLine();
        Console.Write("How many points should you get for completing this goal? ");
        int pointsAwarded = int.Parse(Console.ReadLine());
        Console.Write("After how many completions should you get a bonus? ");
        int requiredCompletions = int.Parse(Console.ReadLine());
        Console.Write("How many bonus points should you be awarded? ");
        int bonusPoints = int.Parse(Console.ReadLine());
        ChecklistGoal checklistGoal = new(title, description, false, pointsAwarded, bonusPoints, requiredCompletions);
        goals.Add(checklistGoal);
    }
    private static void TimedGoal()
    {
        Console.WriteLine("*********************************************************************************");
        Console.WriteLine("Note: Timed goals will apply bonus points if completed before the deadline.");
        Console.WriteLine("      The bonus points will be calculated based on the time taken to complete.");
        Console.WriteLine("      The bonus points will be capped at 300% of the original points awarded.");
        Console.WriteLine("      If the goal is not completed by the deadline, no points will be awarded.");
        Console.WriteLine("      If the goal is completed after 75% of the time has passed, no bonus points");
        Console.WriteLine("      will be awarded.");
        Console.WriteLine("*********************************************************************************\n");
        Console.Write("What is the name of your goal? ");
        string title = Console.ReadLine();
        Console.Write("What is the description of your goal? ");
        string description = Console.ReadLine();
        Console.Write("How many points should you get for completing this goal? ");
        int pointsAwarded = int.Parse(Console.ReadLine());
        Console.WriteLine("When should this goal be completed by?");
        Console.Write("Example: 3d 2h 1m 30s (3 days, 2 hours, 1 minute, 30 seconds) ");
        string time = Console.ReadLine();

        // Calculate the time.
        string[] parts = time.Split(" ");
        int days = 0;
        int hours = 0;
        int minutes = 0;
        int seconds = 0;

        foreach (string part in parts)
        {
            if (part.Contains("d"))
            {
                days = int.Parse(part.Replace("d", ""));
            }
            else if (part.Contains("h"))
            {
                hours = int.Parse(part.Replace("h", ""));
            }
            else if (part.Contains("m"))
            {
                minutes = int.Parse(part.Replace("m", ""));
            }
            else if (part.Contains("s"))
            {
                seconds = int.Parse(part.Replace("s", ""));
            }
        }

        // Convert to seconds.
        int totalSeconds = seconds;
        totalSeconds += days * 24 * 60 * 60;
        totalSeconds += hours * 60 * 60;
        totalSeconds += minutes * 60;

        DateTime deadline = DateTime.Now.AddSeconds(totalSeconds);

        TimedGoal timedGoal = new(title, description, false, pointsAwarded, deadline, DateTime.Now);
        goals.Add(timedGoal);
    }
    private static void ListGoals() {
        string res;
        do
        {
            Console.Clear();
            Console.WriteLine("Your Goals:");
            for (int i = 0; i < goals.Count; i++)
            {
                string status = goals[i].IsCompleted() ? "Completed" : "Not Completed";
                // GitHub Copilot suggested using ((ChecklistGoal)goals[i]).GetBonusPoints() instead of goals[i].GetBonusPoints() as this method is specific to only ChecklistGoal and does not need to be in Goal.cs
                string points = goals[i].ShowType() == "Checklist" ? $"{goals[i].GetPoints()} + {((ChecklistGoal)goals[i]).GetBonusPoints()} bonus points" : goals[i].GetPoints().ToString();
                Console.WriteLine($"{i + 1}. [{goals[i].ShowType()}] {goals[i].GetTitle()} - Points: {points} | {status}");
            }
            Console.WriteLine("press enter to go back");
            res = Console.ReadLine();
        } while (res != "");
    }
    private static void SaveGoals() {
        Console.Clear();
        Console.WriteLine("What is the name of the file you would like to save to?");
        string fileName = Console.ReadLine();
        Console.WriteLine("Saving...");
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine($"totalPoints: {_totalPoints}");
            foreach (Goal goal in goals)
            {
                outputFile.WriteLine(goal.CreateString());
            }
        }
        Console.WriteLine("Saved!");
    }
    private static void LoadGoals()
    {
        Console.Clear();
        Console.WriteLine("What is the name of the file you would like to load from?");
        string fileName = Console.ReadLine();
        Console.WriteLine("Loading...");
        using (StreamReader inputFile = new StreamReader(fileName))
        {
            string line;
            while ((line = inputFile.ReadLine()) != null)
            {
                if (line.Contains("totalPoints"))
                {
                    _totalPoints = int.Parse(line.Split(": ")[1]);
                    continue;
                }
                string[] parts = line.Split(";;");
                switch (parts[4])
                {
                    case "Simple":
                        SimpleGoal simpleGoal = new(parts[0], parts[1], bool.Parse(parts[2]), int.Parse(parts[3]));
                        goals.Add(simpleGoal);
                        break;
                    case "Eternal":
                        EternalGoal eternalGoal = new(parts[0], parts[1], bool.Parse(parts[2]), int.Parse(parts[3]));
                        goals.Add(eternalGoal);
                        break;
                    case "Checklist":
                        ChecklistGoal checklistGoal = new(parts[0], parts[1], bool.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[5]), int.Parse(parts[6]));
                        goals.Add(checklistGoal);
                        break;
                }
            }
        }
        Console.WriteLine("Loaded!");
    }
    private static void RecordEvent()
    {
        Console.Clear();
        Console.WriteLine("Your Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            string status = goals[i].IsCompleted() ? "Completed" : "Not Completed";
            Console.WriteLine($"{i + 1}. [{goals[i].ShowType()}] {goals[i].GetTitle()} - {status}");
        }
        Console.WriteLine("Which goal would you like to mark as completed?");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        _totalPoints += goals[goalIndex].AwardPoints();
        Console.WriteLine(goals[goalIndex].CreateString());
    }
}
