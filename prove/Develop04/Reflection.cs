class Reflection : Activity
{
    List<string> _prompts = new();
    List<string> _questions = new();
    List<int> _usedIndexes = new();
    public Reflection()
    {
        _startingMessage = "Welcome to the reflection activity.";
        _endingMessage = "You have completed the reflection activity.";
        _description = "\nReflection is a powerful tool for personal growth and development. \n" +
            "Take a moment to reflect on your day, your goals, or your emotions. \n" +
            "\nHow long would you like to participate in this activity (in seconds)?";

        _prompts.Add("Think of a time when you stood up for someone else.");
        _prompts.Add("Think of a time when you did something really difficult.");
        _prompts.Add("Think of a time whe nyou helped someone in need.");
        _prompts.Add("Think of a time when you did something truy selfless.");

        _questions.Add("Why was this experience meaningful to you?");
        _questions.Add("Have you ever done anything like this before?");
        _questions.Add("How did you get started?");
        _questions.Add("How did you feel when it was complete?");
        _questions.Add("What made this time different than other times when you were not as successful ?");
        _questions.Add("What is your favorite thing about this experience?");
        _questions.Add("What could you learn from this experience that applies to other situations?");
        _questions.Add("What did you learn about yourself through this experience?");
        _questions.Add("How can you keep this experience in mind in the future?");
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

        // Allow the user to type and submit responses until the time is up
        while (DateTime.Now < end)
        {
            Console.WriteLine($"Date: {DateTime.Now} | Question Index: {index}");
            Console.WriteLine(_questions[index] + "\n");
            index = GetRandomIndex();
            string input = Console.ReadLine();
            
            // Check if the time has run out after the user submits their response
            if (DateTime.Now >= end)
            {
                break;
            }
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
        if (_usedIndexes.Count == _prompts.Count)
        {
            _usedIndexes.Clear();
        }
        while (_usedIndexes.Contains(index))
        {
            index = random.Next(0, _prompts.Count);
        }
        
        _usedIndexes.Add(index);
        return index;
    }
}