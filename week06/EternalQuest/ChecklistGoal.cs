public class ChecklistGoal : Goal
{
    private int targetCount;
    private int currentCount;
    private int bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        this.targetCount = target;
        this.bonus = bonus;
        this.currentCount = 0;
    }

    public override int RecordEvent()
    {
        if (currentCount < targetCount)
        {
            currentCount++;
            if (currentCount == targetCount)
                return Points + bonus;
            return Points;
        }
        return 0;
    }

    public override bool IsComplete() => currentCount >= targetCount;
    public override string GetStatus() => $"[{(IsComplete() ? "X" : " ")}] {Name} ({Description}) -- Completed {currentCount}/{targetCount}";
    public override string GetSaveString() => $"ChecklistGoal|{Name}|{Description}|{Points}|{targetCount}|{bonus}|{currentCount}";
}
