using System;
using System.Collections.Generic;
using System.Threading;

abstract class Activity
{
    protected int duration;
    public void Start()
    {
        Console.WriteLine($"Starting {this.GetType().Name} Activity...");
        Console.WriteLine(GetDescription());
        Console.Write("Enter duration (seconds): ");
        duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        DisplaySpinner(3);
        RunActivity();
        Console.WriteLine($"Good job! You completed the {this.GetType().Name} Activity for {duration} seconds.");
        DisplaySpinner(3);
    }
    protected abstract string GetDescription();
    protected abstract void RunActivity();
    protected void DisplaySpinner(int seconds)
    {
        string[] spinner = {"|", "/", "-", "\\"};
        for (int i = 0; i < seconds * 4; i++)
        {
            Console.Write($"\r{spinner[i % spinner.Length]} ");
            Thread.Sleep(250);
        }
        Console.Write("\r ");
    }
    protected void Countdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
    }
}

class BreathingActivity : Activity
{
    protected override string GetDescription() => "This activity will help you relax by guiding you through deep breathing exercises.";
    protected override void RunActivity()
    {
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine("Breathe in...");
            Countdown(3);
            Console.WriteLine("Breathe out...");
            Countdown(3);
        }
    }
}

class ReflectionActivity : Activity
{
    private static readonly List<string> prompts = new()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need."
    };
    private static readonly List<string> questions = new()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you feel when it was complete?"
    };
    protected override string GetDescription() => "This activity will help you reflect on times in your life when you have shown strength and resilience.";
    protected override void RunActivity()
    {
        Console.WriteLine(prompts[new Random().Next(prompts.Count)]);
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.WriteLine(questions[new Random().Next(questions.Count)]);
            DisplaySpinner(5);
        }
    }
}

class ListingActivity : Activity
{
    private static readonly List<string> prompts = new()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are your personal heroes?"
    };
    protected override string GetDescription() => "This activity will help you reflect on the good things in your life by listing as many things as you can.";
    protected override void RunActivity()
    {
        Console.WriteLine(prompts[new Random().Next(prompts.Count)]);
        Countdown(3);
        List<string> responses = new();
        DateTime endTime = DateTime.Now.AddSeconds(duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("Enter an item: ");
            responses.Add(Console.ReadLine());
        }
        Console.WriteLine($"You listed {responses.Count} items!");
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("\nMindfulness Program");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => throw new InvalidOperationException("Invalid choice")
            };
            if (activity == null) break;
            activity.Start();
        }
    }
}
