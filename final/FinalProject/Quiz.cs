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
    /*
        Polymorphism is used here to override the GetDetails method in the base class.
        For the most part, however, polymorphism is not required because Canvas classifies 
        quizzes as assignments, so the base class can be used for both assignments and quizzes.
        There are different properties, but the base class can be used to store the common properties.
    */
    public override List<string> GetDetails()
    {
        List<string> strings = new();

        strings.Add($"Name: ${_name}");
        strings.Add($"Points: ${_points}");
        strings.Add($"Attempts: {_allowedAttempts}");
        strings.Add($"Due: {_dueDate}");
        strings.Add($"Available From: {_availableFrom}");
        strings.Add($"Available Until: {_availableUntil}");
        strings.Add($"Question Count: {_questionCount}");
        strings.Add($"Time Limit: {_timeLimit}");
        strings.Add($"Proctored: {_isProctored}");
        strings.Add($"Remotely Proctored: {_isRemotelyProctored}");

        return strings;
    }
    public int GetQuestionCount()
    {
        return _questionCount;
    }
    public int GetTimeLimit()
    {
        return _timeLimit;
    }
    public bool IsProctored()
    {
        return _isProctored;
    }
    public bool IsRemotelyProctored()
    {
        return _isRemotelyProctored;
    }
    
}