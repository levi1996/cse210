using System;

public class Activity
{
    private DateTime _date;
    protected int _minutes;

    public Activity(DateTime date, int minutes)
    {
        _date = date;
        _minutes = minutes;
    }

    public virtual double GetDistance() => 0; // km
    public virtual double GetSpeed() => (GetDistance() / _minutes) * 60; // kph
    public virtual double GetPace() => _minutes / GetDistance(); // min/km

    public string GetSummary()
    {
        return $"{_date:dd MMM yyyy} {GetType().Name} ({_minutes} min) - Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.0} min/km";
    }
}