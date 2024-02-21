using System;

public class Address
{
    public string Street { get; }
    public string City { get; }
    public string State { get; }
    public string Country { get; }

    public Address(string street, string city, string state, string country)
    {
        Street = street;
        City = city;
        State = state;
        Country = country;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {Country}";
    }
}

public abstract class Event
{
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime Date { get; set; }
    public TimeSpan Time { get; set; }
    public Address Address { get; set; }

    protected Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        Title = title;
        Description = description;
        Date = date;
        Time = time;
        Address = address;
    }

    public virtual string GetStandardDetails()
    {
        return $"{Title} on {Date.ToShortDateString()} at {Time.ToString(@"hh\:mm")} - {Description} - Location: {Address}";
    }

    public abstract string GetFullDetails();

    public string GetShortDescription()
    {
        return $"{GetType().Name} - {Title} on {Date.ToShortDateString()}";
    }
}

public class Lecture : Event
{
    public string Speaker { get; set; }
    public int Capacity { get; set; }

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        Speaker = speaker;
        Capacity = capacity;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()} Speaker: {Speaker}, Capacity: {Capacity}";
    }
}

public class Reception : Event
{
    public string EmailForRSVP { get; set; }

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string emailForRSVP)
        : base(title, description, date, time, address)
    {
        EmailForRSVP = emailForRSVP;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()} RSVP at: {EmailForRSVP}";
    }
}

public class OutdoorGathering : Event
{
    public string WeatherForecast { get; set; }

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherForecast)
        : base(title, description, date, time, address)
    {
        WeatherForecast = weatherForecast;
    }

    public override string GetFullDetails()
    {
        return $"{GetStandardDetails()} Weather: {WeatherForecast}";
    }
}

class Program
{
    static void Main()
    {
        Event lecture = new Lecture("C# Fundamentals", "Learn C# basics", new DateTime(2023, 10, 15), new TimeSpan(14, 0, 0), new Address("123 Main St", "Tech City", "TS", "USA"), "John Doe", 100);
        Event reception = new Reception("Tech Conference Reception", "Networking event", new DateTime(2023, 10, 16), new TimeSpan(18, 30, 0), new Address("456 Grand Ave", "Tech City", "TS", "USA"), "info@techconf.com");
        Event outdoorGathering = new OutdoorGathering("Tech Park Meetup", "Casual tech talks", new DateTime(2023, 10, 17), new TimeSpan(12, 0, 0), new Address("789 Park Lane", "Tech City", "TS", "USA"), "Sunny with a chance of showers");

        PrintEventDetails(lecture);
        PrintEventDetails(reception);
        PrintEventDetails(outdoorGathering);
    }

    static void PrintEventDetails(Event eventObj)
    {
        Console.WriteLine(eventObj.GetStandardDetails());
        Console.WriteLine(eventObj.GetFullDetails());
        Console.WriteLine(eventObj.GetShortDescription());
        Console.WriteLine(new string('-', 40));
    }
}
