class ChecklistGoal : Goal
{
    private int TargetCount;
    private int CurrentCount;
    private int Bonus;
    
    public ChecklistGoal(string name, int points, int targetCount, int bonus) : base(name, points)
    {
        TargetCount = targetCount;
        CurrentCount = 0;
        Bonus = bonus;
    }

    public override int RecordProgress()
    {
        if (CurrentCount < TargetCount)
        {
            CurrentCount++;
            if (CurrentCount == TargetCount)
            {
                IsComplete = true;
                return Points + Bonus;
            }
            return Points;
        }
        return 0;
    }

    public override string GetStatus() => (IsComplete ? "[X] " : "[ ] ") + $"{Name} ({CurrentCount}/{TargetCount})";
    public override string Serialize() => $"Checklist|{Name}|{Points}|{TargetCount}|{CurrentCount}|{Bonus}";
}
