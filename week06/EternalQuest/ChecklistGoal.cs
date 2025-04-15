public class ChecklistGoal : Goal
{
    private int _points;
    private int _bonusPoints;
    private int _targetCount;
    private int _completedCount;

    public ChecklistGoal(string name, string description, int points, int bonusPoints, int targetCount, int completedCount = 0)
    {
        Name = name;
        Description = description;
        _points = points;
        _bonusPoints = bonusPoints;
        _targetCount = targetCount;
        _completedCount = completedCount;
    }

    public override int RecordEvent()
    {
        if (_completedCount >= _targetCount)
        {
            Console.WriteLine("Checklist goal is already completed.");
            return 0;
        }

        _completedCount++;
        int pointsEarned = _points;

        if (_completedCount == _targetCount)
        {
            pointsEarned += _bonusPoints;
            Console.WriteLine($"You completed the goal '{Name}' and earned a bonus of {_bonusPoints} points.");
        }

        Console.WriteLine($"You earned {pointsEarned} points for the goal '{Name}'.");
        return pointsEarned;
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal|{Name}|{Description}|{_points}|{_bonusPoints}|{_targetCount}|{_completedCount}";
    }

    public override string ShortName => Name;

    // Override Display to show current progress
    public override void Display()
    {
        Console.WriteLine($"[{_completedCount}/{_targetCount}] {Name} ({Description}) - {_points} pts each, Bonus: {_bonusPoints} pts");
    }
}