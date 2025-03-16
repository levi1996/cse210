using System;

abstract class Goal
{
    public string Name { get; protected set; }
    public int Points { get; protected set; }
    public bool IsComplete { get; protected set; }

    public Goal(string name, int points)
    {
        Name = name;
        Points = points;
        IsComplete = false;
    }
    
    public abstract int RecordProgress();
    public abstract string GetStatus();
    public abstract string Serialize();

    public static Goal Deserialize(string data)
    {
        string[] parts = data.Split('|');
        string type = parts[0];

        return type switch
        {
            "Simple" => new SimpleGoal(parts[1], int.Parse(parts[2]), bool.Parse(parts[3])),
            "Eternal" => new EternalGoal(parts[1], int.Parse(parts[2])),
            "Checklist" => new ChecklistGoal(parts[1], int.Parse(parts[2]), int.Parse(parts[3]), int.Parse(parts[4])),
            _ => throw new Exception("Unknown goal type")
        };
    }
}
