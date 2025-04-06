using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        var activities = new List<Activity>
        {
            new Running(new DateTime(2023, 10, 1), 30, 4.8),
            new Cycling(new DateTime(2023, 10, 2), 45, 20.5),
            new Swimming(new DateTime(2023, 10, 3), 60, 40)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}