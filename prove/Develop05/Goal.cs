class Goal
{
    protected string _title = "";
    protected string _description = "";
    protected bool _isComplete = false;
    protected int _pointsAwarded = 0;
    protected string _type = "";

    protected void SetGoal(string title, string description, bool isComplete, int pointsAwarded, string type)
    {
        _title = title;
        _description = description;
        _isComplete = isComplete;
        _pointsAwarded = pointsAwarded;
        _type = type;
    }
    public string GetTitle()
    {
        return _title;
    }
    public string ShowType()
    {
        return _type;
    }
    public bool IsCompleted()
    {
        return _isComplete;
    }
    protected virtual void MarkAsCompleted()
    {
        _isComplete = true;
    }
    public virtual int AwardPoints() {
        MarkAsCompleted();
        return _pointsAwarded;
    }
    public virtual string CreateString() 
    {
        return $"{_title};;{_description};;{_isComplete};;{_pointsAwarded};;{_type}";
    }
    public int GetPoints()
    {
        return _pointsAwarded;
    }
}