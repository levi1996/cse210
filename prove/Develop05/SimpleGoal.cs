class SimpleGoal : Goal
{
    public SimpleGoal(string name, int points, bool isComplete = false) : base(name, points)
    {
        IsComplete = isComplete;
    }

    public override int RecordProgress()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            return Points;
        }
        return 0;
    }

    public override string GetStatus() => IsComplete ? "[X] " + Name : "[ ] " + Name;
    public override string Serialize() => $"Simple|{Name}|{Points}|{IsComplete}";
}
