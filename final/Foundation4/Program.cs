using System;
using System.Collections.Generic;

public abstract class Activity
{
    public DateTime Date { get; }
    public int DurationInMinutes { get; }

    protected Activity(DateTime date, int durationInMinutes)
    {
        Date = date;
        DurationInMinutes = durationInMinutes;
    }

    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    public virtual string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")}: {GetType().Name} ({DurationInMinutes} min) - Distance: {GetDistance()} miles, Speed: {GetSpeed():0.0} mph, Pace: {GetPace():0.0} min per mile";
    }
}

public class Running : Activity
{
    public double DistanceInMiles { get; }

    public Running(DateTime date, int durationInMinutes, double distanceInMiles)
        : base(date, durationInMinutes)
    {
        DistanceInMiles = distanceInMiles;
    }

    public override double GetDistance() => DistanceInMiles;
    public override double GetSpeed() => (DistanceInMiles / DurationInMinutes) * 60;
    public override double GetPace() => DurationInMinutes / DistanceInMiles;
}

public class Cycling : Activity
{
    public double SpeedInMph { get; }

    public Cycling(DateTime date, int durationInMinutes, double speedInMph)
        : base(date, durationInMinutes)
    {
        SpeedInMph = speedInMph;
    }

    public override double GetDistance() => (SpeedInMph * DurationInMinutes) / 60;
    public override double GetSpeed() => SpeedInMph;
    public override double GetPace() => 60 / SpeedInMph;
}

public class Swimming : Activity
{
    public int NumberOfLaps { get; }

    public Swimming(DateTime date, int durationInMinutes, int numberOfLaps)
        : base(date, durationInMinutes)
    {
        NumberOfLaps = numberOfLaps;
    }

    public override double GetDistance() => NumberOfLaps * 50 / 1000.0 * 0.62; // Converting meters to miles
    public override double GetSpeed() => GetDistance() / (DurationInMinutes / 60.0);
    public override double GetPace() => DurationInMinutes / GetDistance();
}

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new Running(new DateTime(2022, 11, 03), 30, 3.0),
            new Cycling(new DateTime(2022, 11, 04), 45, 15.0),
            new Swimming(new DateTime(2022, 11, 05), 60, 30)
        };

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
