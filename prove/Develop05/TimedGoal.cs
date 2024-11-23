class TimedGoal : Goal
{
    private DateTime _deadline;
    private DateTime _startTime;

    public TimedGoal(string title, string description, bool isComplete, int pointsAwarded, DateTime deadline, DateTime startTime)
    {
        SetGoal(title, description, isComplete, pointsAwarded, "Timed");
        _deadline = deadline;
        _startTime = startTime;
    }
    public DateTime GetDeadline()
    {
        return _deadline;
    }
    public bool IsOverdue()
    {
        return DateTime.Now > _deadline;
    }
    
    public override string CreateString()
    {
        return $"{_title};;{_description};;{_isComplete};;{_pointsAwarded};;{_type};;{_deadline};;{_startTime}";
    }
    public override int AwardPoints()
    {
        if (IsOverdue())
        {
            MarkAsCompleted();
            return 0;
        }
        else
        {
            MarkAsCompleted();

            // GitHub Copilot assisted with the logic to create a boost to _pointsAwarded based on competion time.
            // It speciically helped with the TimeSpan structure.
            TimeSpan duration = _deadline - _startTime;
            TimeSpan timeTaken = DateTime.Now - _startTime;
            double completed = (timeTaken.TotalSeconds / duration.TotalSeconds) * 100;
            double boost = completed >= 76 ? 0 : 200 - completed;

            int boostPts = (int)(+_pointsAwarded * (1 + boost / 100)); // Casting to int to remove decimal points (suggested by GitHub Copilot)
            
            _pointsAwarded = boostPts;
            return boostPts; // Returns _pointsAwarded multiplied by a percentage boost based on completion time.
        }
    }
}