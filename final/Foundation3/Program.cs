using System;

class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    public override string ToString() => $"{Street}, {City}, {Country}";
}

abstract class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    protected Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        title = title;
        description = description;
        date = date;
        time = time;
        address = address;
    }

    public virtual string GetStandardDetails() => $"Title: {title}, Description: {description}, Date: {date.ToShortDateString()}, Time: {time}, Address: {address}";
}

class Conference : Event
{
    private string speakerName;
    private int speakerCapacity;

    public Conference(string title, string description, DateTime date, TimeSpan time, Address address, string speakerName, int speakerCapacity)
        : base(title, description, date, time, address)
    {
        this.speakerName = speakerName;
        this.speakerCapacity = speakerCapacity;
    }

    public override string GetStandardDetails() => $"{base.GetStandardDetails()}, Type: Conference, Speaker: {speakerName}, Speaker Capacity: {speakerCapacity}";
}

class Reception : Event
{
    private string confirmationEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string confirmationEmail)
        : base(title, description, date, time, address)
    {
        this.confirmationEmail = confirmationEmail;
    }

    public override string GetStandardDetails() => $"{base.GetStandardDetails()}, Type: Reception, Confirmation Email: {confirmationEmail}";
}

class OutdoorMeeting : Event
{
    private string weatherForecast;

    public OutdoorMeeting(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        this.weatherForecast = weatherForecast;
    }

    public override string GetStandardDetails() => $"{base.GetStandardDetails()}, Type: Outdoor Meeting, Weather Forecast: {weatherForecast}";
}

class Program
{
    static void Main(string[] args)
    {
        Address eventAddress = new Address() { Street = "Main Street 123", City = "Example City", Country = "Example Country" };

        var conference = new Conference("Example Conference", "Conference Description", DateTime.Now, TimeSpan.FromHours(10), eventAddress, "Dr. Speaker", 100);
        var reception = new Reception("Example Reception", "Reception Description", DateTime.Now, TimeSpan.FromHours(18), eventAddress, "email@example.com");
        var outdoorMeeting = new OutdoorMeeting("Example Outdoor Meeting", "Outdoor Meeting Description", DateTime.Now, TimeSpan.FromHours(14), eventAddress, "Sunny");

        PrintDetails(conference);
        PrintDetails(reception);
        PrintDetails(outdoorMeeting);
    }

    static void PrintDetails(Event ev)
    {
        Console.WriteLine($"Event Details:");
        Console.WriteLine(ev.GetStandardDetails());
        Console.WriteLine();
    }
}
