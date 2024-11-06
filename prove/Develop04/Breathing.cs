class Breathing : Activity
{
    public Breathing()
    {
        _startingMessage = "Welcome to the breathing activity.";
        _endingMessage = "You have completed the breathing activity.";
        _description = "\nBreathing is a simple and effective way to calm your mind and relax your body. \n" +
            "Take a deep breath in through your nose, hold it for a few seconds, and then exhale through your mouth. \n" +
            "\nHow long would you like to practice this activity (in seconds)?";

    }
    public void Start()
    {
        Console.Clear();
        DisplayStartDetails();

        string duration = Console.ReadLine();
        Console.WriteLine("\n\n");
        int dur = int.Parse(duration);

        while (dur > 0) 
        {
            if (dur >= 10)
            {
                Breathe("in", 5);
                Breathe("out", 5);
                dur -= 10;
            } else if (dur < 10)
            {
                Breathe("in", 5);
                int remaining = 10 - dur;
                Breathe("out", remaining);
                dur -= 5 + remaining;
            } else if (dur <= 5) {
                dur = 0;
            }
        }

        Console.WriteLine(_endingMessage);
        Console.Write("One moment ");
        Spinner(5);
        Console.Clear();

    }
    private void Breathe(string action, int duration)
    {
        // Clear the console and set the initial cursor position
        Console.Clear();
        string[] inArt = {
            "█████████    █████████    ██████████    ████████   ██████████   ███    ███   ██████████          ███   █████████    ",
            "███    ███   ███    ███   ███          ███    ███     ███       ███    ███   ███                 ███   ███    ███   ",
            "███    ███   ███    ███   ███          ███    ███     ███       ███    ███   ███                 ███   ███    ███   ",
            "█████████    █████████    ████████     ██████████     ███       ██████████   ████████            ███   ███    ███   ",
            "███    ███   ███    ███   ███          ███    ███     ███       ███    ███   ███                 ███   ███    ███   ",
            "███    ███   ███    ███   ███          ███    ███     ███       ███    ███   ███                 ███   ███    ███   ",
            "█████████    ███    ███   ██████████   ███    ███     ███       ███    ███   ██████████          ███   ███    ███   "
        };

        string[] outArt = {
            "█████████    █████████    ██████████    ████████   ██████████   ███    ███   ██████████          ████████    ███    ███   ██████████   ",
            "███    ███   ███    ███   ███          ███    ███     ███       ███    ███   ███                ███    ███   ███    ███      ███       ",
            "███    ███   ███    ███   ███          ███    ███     ███       ███    ███   ███                ███    ███   ███    ███      ███       ",
            "█████████    █████████    ████████     ██████████     ███       ██████████   ████████           ███    ███   ███    ███      ███       ",
            "███    ███   ███    ███   ███          ███    ███     ███       ███    ███   ███                ███    ███   ███    ███      ███       ",
            "███    ███   ███    ███   ███          ███    ███     ███       ███    ███   ███                ███    ███   ███    ███      ███       ",
            "█████████    ███    ███   ██████████   ███    ███     ███       ███    ███   ██████████          ████████     ████████       ███       "
        };

        // Display the ASCII art for the breathing exercise based on the action. (Turnary Operator)
        string[] art = action == "in" ? inArt : outArt;
        int consoleWidth = Console.WindowWidth -1;

        if (art[0].Length > consoleWidth)
        {
            Console.WriteLine($"Breathe {action} for {duration} seconds.");
        } 
        else
        {
            foreach (string line in art)
            {
                int padding = (consoleWidth - line.Length) / 2;
                Console.WriteLine(line.PadLeft(line.Length + padding));
            }
        }

        // Set the invert flag based on the action.
        bool invert = false;
        if (action == "in")
        {
            invert = true;
        }
        Console.SetCursorPosition(0, 7);
        ProgressBar(duration, invert);
    }
}