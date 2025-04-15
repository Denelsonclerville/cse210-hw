public class SimpleGoal : Goal
{
    private int _points;
    private bool _completed;

    public SimpleGoal(string name, string description, int points, bool completed = false)
    {
        Name = name;
        Description = description;
        _points = points;
        _completed = completed;
    }

    // Method to record an event (mark the goal as completed and award points)
    public override int RecordEvent()
    {
        if (_completed)
        {
            Console.WriteLine("This goal is already completed.");
            return 0;
        }

        _completed = true;
        Console.WriteLine($"You have completed the goal '{Name}' and earned {_points} points.");
        return _points;
    }

    // Method to get the save string representation of the goal
    public override string GetSaveString()
    {
        return $"SimpleGoal|{Name}|{Description}|{_points}|{_completed}";
    }

    public override string ShortName => Name;

    // Override Display to show completion status
    public override void Display()
    {
        string status = _completed ? "[X]" : "[ ]";
        Console.WriteLine($"{status} {Name} ({Description}) - {_points} points");
    }
}
