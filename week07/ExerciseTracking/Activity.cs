using System.Globalization;
public abstract class Activity
{
    private DateTime _date;
    protected int _minutes;

    public Activity(string date, int minutes)
    {
        _date = DateTime.ParseExact(date, "dd MMM yyyy", CultureInfo.InvariantCulture);
        _minutes = minutes;
    }

    public DateTime Date => _date;
    public int Minutes => _minutes;

    // Abstract methods
    public abstract double GetDistance(); // in km
    public abstract double GetSpeed();    // in km/h
    public abstract double GetPace();     // in min/km

    // Summary method calls overridden methods (virtual dispatch)
    public virtual string GetSummary()
    {
        return $"{Date:dd MMM yyyy} {this.GetType().Name} ({_minutes} min): " +
               $"Distance: {GetDistance():0.0} km, Speed: {GetSpeed():0.0} kph, Pace: {GetPace():0.00} min per km";
    }
}