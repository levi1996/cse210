using System;

public class Resume
{
    public string _name;
    public List<Job> _jobs = new List<Job>();

    // Method to display resume details
    public void Display()
    {
        Console.WriteLine($"Name: {_name}");
        Console.WriteLine("Jobs:");
        foreach (var job in _jobs)
        {
            job.Display();
        }
    }
}