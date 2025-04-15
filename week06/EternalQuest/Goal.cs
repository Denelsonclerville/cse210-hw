public abstract class Goal
{
    public string Name { get; protected set; }
    public string Description { get; protected set; }

    
    public virtual void Display()
    {
        Console.WriteLine($"{Name}: {Description}");
    }

    public abstract string GetSaveString();
    
    
    public abstract int RecordEvent();

    
    public abstract string ShortName { get; }
}
