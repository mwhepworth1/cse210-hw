class Listing : Activity
{
    List<string> _prompts = new();
    List<int> _usedIndexes = new();
    public Listing()
    {
        _startingMessage = "Welcome to the listing activity.";
        _endingMessage = "You have completed the listing activity.";
        _description = "\nListing is a powerful tool for personal growth and development. \n" +
            "Take a moment to list your day, your goals, or your emotions. \n" +
            "\nHow long would you like to participate in this activity (in seconds)?";

        _prompts.Add("Who are people that you appreciate?");
        _prompts.Add("What are personal strengths of yours?");
        _prompts.Add("Who are people that you have helped this week? ");
        _prompts.Add("When have you felt the Holy Ghost this month? ");
        _prompts.Add("Who are some of your personal heroes?");
    }

    public void Start()
    {
        Console.Clear();
        DisplayStartDetails();

        string duration = Console.ReadLine();
        Console.WriteLine("\n\n");
        int dur = int.Parse(duration);
        DateTime start = DateTime.Now;
        DateTime end = start.AddSeconds(dur);
        int index = GetRandomIndex();
        Console.WriteLine(_prompts[index] + "\n");

        while (DateTime.Now < end)
        {
            string input = Console.ReadLine();
            continue;
        }

        Console.WriteLine(_endingMessage);
        Console.Write("One moment ");
        Spinner(5);
        Console.Clear();
    }
    private int GetRandomIndex()
    {
        Random random = new();
        int index = random.Next(0, _prompts.Count);
        while (_usedIndexes.Contains(index))
        {
            index = random.Next(0, _prompts.Count);
        }
        if (_usedIndexes.Count == _prompts.Count)
        {
            _usedIndexes.Clear();
        }
        _usedIndexes.Add(index);
        return index;
    }
}
