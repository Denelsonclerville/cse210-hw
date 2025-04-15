public class EternalGoal : Goal
{
    private int _points;

    public EternalGoal(string name, string description, int points)
    {
        Name = name;
        Description = description;
        _points = points;
    }

    // Method to record an event (points are awarded, but the goal is not completed)
    public override int RecordEvent()
    {
        Console.WriteLine($"You have earned {_points} points for the eternal goal '{Name}'.");
        return _points;
    }

    public override string GetSaveString()
    {
        return $"EternalGoal|{Name}|{Description}|{_points}";
    }

    public override string ShortName => Name;

    // Override Display for special symbol and no completion state
    public override void Display()
    {
        Console.WriteLine($"[∞] {Name} ({Description}) - {_points} pts per completion");
    }
}