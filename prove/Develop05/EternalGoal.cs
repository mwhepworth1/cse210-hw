class EternalGoal : Goal
{
    public EternalGoal(string title, string description, bool isComplete, int pointsAwarded)
    {
        SetGoal(title, description, isComplete, pointsAwarded, "Eternal");
    }
    protected override void MarkAsCompleted()
    {
        _isComplete = false;
    }
}