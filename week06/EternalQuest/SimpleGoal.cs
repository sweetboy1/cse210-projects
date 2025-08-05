public class SimpleGoal : Goal
{
    private bool completed = false;

    public SimpleGoal(string name, string description, int points) : base(name, description, points) { }

    public override int RecordEvent()
    {
        if (!completed)
        {
            completed = true;
            return Points;
        }
        return 0;
    }

    public override bool IsComplete() => completed;
    public override string GetStatus() => $"[{"X",1}] {Name} ({Description})";
    public override string GetSaveString() => $"SimpleGoal|{Name}|{Description}|{Points}|{completed}";
}
