class Quiz : Assignment
{
    protected int _questionCount = 0;
    protected int _timeLimit = -1; // No limit; seconds
    protected bool _isProctored = false;
    protected bool _isRemotelyProctored = false;

    // Calling the base class's constructor like so was suggested by GitHub Copilot
    // I asked how I could fix the error where the parameters didn't line up
    // and it suggested that I use the base constructor (since Assignment will be used
    // as a normal class and a quiz is a variation of the assignment class.)
    public Quiz(string name, int points, DateTime dueDate, int allowedAttempts, DateTime availableFrom, DateTime availableUntil, int questionCount, int timeLimit, bool isProctored, bool isRemotelyProctored, bool completed)
        : base(name, points, dueDate, allowedAttempts, availableFrom, availableUntil, completed)
    {
        _questionCount = questionCount;
        _timeLimit = timeLimit;
        _isProctored = isProctored;
        _isRemotelyProctored = isRemotelyProctored;
    }
}