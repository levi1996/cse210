using System;

class Program
{
    static void Main()
    {
        var address = new Address("123 Park Ave", "New York", "NY");
        
        var lecture = new Lecture("C# Basics", "Intro to C#", "2023-10-15", "2:00 PM", address, "Dr. Smith", 100);
        var reception = new Reception("Company Party", "Annual Celebration", "2023-12-20", "6:00 PM", address, "rsvp@company.com");
        var outdoor = new OutdoorGathering("Summer Fest", "Music and Food", "2024-07-04", "12:00 PM", address, "Sunny");

        Event[] events = { lecture, reception, outdoor };

        foreach (var ev in events)
        {
            Console.WriteLine(ev.GetStandardDetails());
            Console.WriteLine("\n" + ev.GetFullDetails());
            Console.WriteLine("\n" + ev.GetShortDescription() + "\n");
            Console.WriteLine("----------------------------------\n");
        }
    }
}