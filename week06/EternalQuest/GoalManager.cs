public class GoalManager
{

    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    private int CalculateLevel()
    {
        return _score / 1000 + 1;
    }

    public void ListGoals()
    {

        Console.WriteLine("\nYour Goals:");
        int count = 1;
        foreach (Goal goal in _goals)
        {
            Console.Write($"{count}. ");
            goal.Display();
            count++;
        }

        int level = CalculateLevel();
        int progress = _score % 1000;
        int total = 1000;
        int barWidth = 20;
        int filled = (progress * barWidth) / total;
        string bar = new string('#', filled).PadRight(barWidth, '-');

        Console.WriteLine($"\nCurrent Score: {_score} points");
        Console.WriteLine($"Level: {level}");
        Console.WriteLine($"Progress to next level: [{bar}] {progress}/{total}\n");
    }

    public void CreateGoal()
    {

        Console.WriteLine("What type of goal would you like to create?: ");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which goal do you like to create?: ");
        string choice = Console.ReadLine();
        Console.Write("Enter the name of the goal: ");
        string name = Console.ReadLine();
        Console.Write("Enter goal description: ");
        string description = Console.ReadLine();

        switch (choice)
        {
            case "1":
                Console.Write("Enter point value: ");
                int simplePoints = int.Parse(Console.ReadLine());
                _goals.Add(new SimpleGoal(name, description, simplePoints));
                break;

            case "2":
                Console.Write("Enter the amount of point? : ");
                int eternalPoints = int.Parse(Console.ReadLine());
                _goals.Add(new EternalGoal(name, description, eternalPoints));
                break;

            case "3":
                Console.Write("Enter the amount of point? : ");
                int checklistPoints = int.Parse(Console.ReadLine());
                Console.Write("Enter number of times to complete: ");
                int targetCount = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, checklistPoints, bonus, targetCount));
                break;

            default:
                Console.WriteLine("Invalid option.");
                break;

        Console.WriteLine("Invalid option.");   
        }
    }

    public void RecordEvent()
    {

        Console.WriteLine("Select a goal to record progress:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }

        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= _goals.Count)
        {
            Goal selectedGoal = _goals[choice - 1];
            int earnedPoints = selectedGoal.RecordEvent();
            _score += earnedPoints;

            Console.WriteLine($"You earned {earnedPoints} points!");
            ListGoals();
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
    }

    public void SaveToFile(string filename)
    {

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetSaveString());
            }
        }

        Console.WriteLine($"Goals successfully saved to '{filename}'");
    }

    public void LoadFromFile(string filename)
    {

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();
        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split('|');
            string type = parts[0];

            switch (type)
            {
                case "SimpleGoal":
                    _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
                    break;

                case "EternalGoal":
                    _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                    break;

                case "ChecklistGoal":
                    _goals.Add(new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6])));
                    break;

                default:
                    Console.WriteLine($"Unknown goal type: {type}");
                    break;
            }
        }

        Console.WriteLine($"Goals successfully loaded from '{filename}'");
    }
}
