class Assignment
{
    protected string _name;
    protected int _points;
    protected DateTime _dueDate;
    protected int _allowedAttempts = -1;
    protected DateTime _availableFrom;
    protected DateTime _availableUntil;

    public Assignment(string name, int points, DateTime dueDate, int allowedAttempts, DateTime availableFrom, DateTime availableUntil)
    {
        CreateItem(name, points, dueDate, allowedAttempts, availableFrom, availableUntil);
    }

    protected void CreateItem(string name, int points, DateTime dueDate, int allowedAttempts, DateTime availableFrom, DateTime availableUntil)
    {
        _name = name;
        _points = points;
        _dueDate = dueDate;
        _allowedAttempts = allowedAttempts;
        _availableFrom = availableFrom;
        _availableUntil = availableUntil;
    }
    public virtual List<string> GetDetails()
    {
        List<string> strings = new();

        strings.Add($"Name: ${_name}");
        strings.Add($"Points: ${_points}");
        strings.Add($"Attempts: {_allowedAttempts}");
        strings.Add($"Due: {_dueDate}");
        strings.Add($"Available From: {_availableFrom}");
        strings.Add($"Available Until: {_availableUntil}");

        return strings;
    }
    public bool IsAvailable()
    {
        return (DateTime.Now < _availableFrom) && (DateTime.Now > _availableUntil);
    }
    public DateTime GetDueDate()
    {
        return _dueDate.AddHours(-24);
    }
    public string GetTitle()
    {
        return _name;
    }
}