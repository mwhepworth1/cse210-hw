class SimpleGoal : Goal
{
    public SimpleGoal(string title, string description, bool isComplete, int pointsAwarded)
    {
        SetGoal(title, description, isComplete, pointsAwarded, "Simple");
    }
    
}