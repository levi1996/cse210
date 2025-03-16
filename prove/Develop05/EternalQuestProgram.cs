using System;
using System.Collections.Generic;
using System.IO;

class EternalQuestProgram
{
    private List<Goal> goals = new();
    private int totalScore = 0;
    private const string FileName = "goals.txt";

    public void Run()
    {
        LoadGoals();
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Total Score: {totalScore}\n");
            Console.WriteLine("1. Create a new goal");
            Console.WriteLine("2. Record progress on a goal");
            Console.WriteLine("3. Show goals");
            Console.WriteLine("4. Save and exit");
            Console.Write("Select an option: ");
            string input = Console.ReadLine();
            
            switch (input)
            {
                case "1": CreateGoal(); break;
                case "2": RecordProgress(); break;
                case "3": ShowGoals(); break;
                case "4": SaveGoals(); return;
                default: Console.WriteLine("Invalid input. Try again."); break;
            }
        }
    }

    private void CreateGoal()
    {
        Console.WriteLine("Choose goal type: 1. Simple, 2. Eternal, 3. Checklist");
        string choice = Console.ReadLine();
        Console.Write("Enter goal name: ");
        string name = Console.ReadLine();
        Console.Write("Enter point value: ");
        int points = int.Parse(Console.ReadLine());
        
        Goal goal = choice switch
        {
            "1" => new SimpleGoal(name, points),
            "2" => new EternalGoal(name, points),
            "3" => CreateChecklistGoal(name, points),
            _ => null
        };

        if (goal != null) goals.Add(goal);
    }

    private ChecklistGoal CreateChecklistGoal(string name, int points)
    {
        Console.Write("Enter target count: ");
        int target = int.Parse(Console.ReadLine());
        Console.Write("Enter bonus points: ");
        int bonus = int.Parse(Console.ReadLine());
        return new ChecklistGoal(name, points, target, bonus);
    }

    private void RecordProgress()
    {
        ShowGoals();
        Console.Write("Enter goal number to record progress: ");
        int index = int.Parse(Console.ReadLine()) - 1;
        if (index >= 0 && index < goals.Count)
        {
            totalScore += goals[index].RecordProgress();
            Console.WriteLine("Progress recorded!");
        }
        Console.ReadLine();
    }

    private void ShowGoals()
    {
        for (int i = 0; i < goals.Count; i++)
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        Console.ReadLine();
    }

    private void SaveGoals()
    {
        using StreamWriter outputFile = new(FileName);
        outputFile.WriteLine(totalScore);
        foreach (Goal goal in goals)
            outputFile.WriteLine(goal.Serialize());
    }

    private void LoadGoals()
    {
        if (File.Exists(FileName))
        {
            string[] lines = File.ReadAllLines(FileName);
            totalScore = int.Parse(lines[0]);
            for (int i = 1; i < lines.Length; i++)
                goals.Add(Goal.Deserialize(lines[i]));
        }
    }
}
