class ChecklistGoal : Goal
{
    private int _timesCompleted = 0;
    private int _bonusPoints = 0;
    private int _requiredCompletions = 0;
    public ChecklistGoal(string title, string description, bool isComplete, int pointsAwarded, int bonusPoints, int requiredCompletions, int timesCompleted = 0)
    {
        SetGoal(title, description, isComplete, pointsAwarded, "Checklist");
        _bonusPoints = bonusPoints;
        _requiredCompletions = requiredCompletions;
        _timesCompleted = timesCompleted;
    }
    protected override void MarkAsCompleted()
    {
        _isComplete = true;
    }
    public override int AwardPoints()
    {
        _timesCompleted++;
        if ((_timesCompleted % _requiredCompletions == 0) && (_timesCompleted >= _requiredCompletions))
        {
            MarkAsCompleted();
            return _pointsAwarded + _bonusPoints;
        } else
        {
            return _pointsAwarded;
        }
    }
    public override string CreateString()
    {
        return $"{_title};;{_description};;{_isComplete};;{_pointsAwarded};;{_type};;{_bonusPoints};;{_requiredCompletions};;{_timesCompleted}";
    }
    public int GetBonusPoints()
    {
        return _bonusPoints;
    }
    public int GetRequiredCompletions()
    {
        return _requiredCompletions;
    }
}