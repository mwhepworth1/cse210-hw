class Activity
{
    protected string _startingMessage;
    protected string _endingMessage;

    public static void DurationTimer(int duration)
    {
        int milliseconds = duration * 1000;
        Thread.Sleep(milliseconds);
    }
    public static void Spinner(int duration)
    {
        string[] spinner = { "|", "/", "―", "\\" };
        int milliseconds = duration * 1000;
        int interval = 50;
        int index = 0;
        int count = 0;
        while (count < milliseconds)
        {
            Console.Write(spinner[index]);
            Thread.Sleep(interval);
            Console.Write("\b \b");
            index++;
            if (index == spinner.Length)
            {
                index = 0;
            }
            count += interval;
        }
    }
    
}