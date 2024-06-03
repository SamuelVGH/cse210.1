using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<Activity> activities = new List<Activity>();

        activities.Add(new Running { Date = new DateTime(2022, 11, 3), Duration = 30, Distance = 3.0 });
        activities.Add(new Running { Date = new DateTime(2022, 11, 3), Duration = 30, Distance = 4.8 });
        activities.Add(new Cycling { Date = new DateTime(2022, 11, 3), Duration = 30, Speed = 9.7 });
        activities.Add(new Swimming { Date = new DateTime(2022, 11, 3), Duration = 30, Laps = 10 });

        foreach (var activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}


class Activity
{
    public DateTime Date { get; set; }
    public int Duration { get; set; }

    public virtual double GetDistance()
    {
        return 0;
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    public virtual string GetSummary()
    {
        return "";
    }
}

class Running : Activity
{
    public double Distance { get; set; }

    public override double GetDistance()
    {
        return Distance;
    }

    public override double GetSpeed()
    {
        return (Distance / Duration) * 60;
    }

    public override double GetPace()
    {
        return Duration / Distance;
    }

    public override string GetSummary()
    {
        return $"{Date} Running ({Duration} min): distance {Distance} miles, speed {GetSpeed()} mph, pace: {GetPace()} min per mile";
    }
}

class Cycling : Activity
{
    public double Speed { get; set; }

    public override double GetDistance()
    {
        return (Speed * Duration) / 60;
    }

    public override double GetSpeed()
    {
        return Speed;
    }

    public override double GetPace()
    {
        return 60 / Speed;
    }

    public override string GetSummary()
    {
        return $"{Date} Cycling ({Duration} min): distance {GetDistance()} miles, speed {Speed} mph, pace: {GetPace()} min per mile";
    }
}

class Swimming : Activity
{
    public int Laps { get; set; }

    public override double GetDistance()
    {
        return Laps * 50 / 1000.0;
    }

    public override double GetSpeed()
    {
        return GetDistance() / (Duration / 60.0);
    }

    public override double GetPace()
    {
        if (Duration == 0)
        {
            return 0;
        }

        return (Duration / 60.0) / GetDistance();
    }

    public override string GetSummary()
    {
        return $"{Date} Swimming ({Duration} min): distance {GetDistance()} km, speed {GetSpeed()} km/h, pace: {GetPace()} min per km";
    }
}

