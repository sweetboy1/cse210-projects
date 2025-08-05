public class LevelSystem
{
    public int TotalPoints { get; private set; } = 0;
    public int Level => TotalPoints / 1000;
    public string Title => Level switch
    {
        < 1 => "Beginner",
        < 3 => "Disciple",
        < 5 => "Seeker",
        < 8 => "Master",
        _ => "Legend"
    };

    public void AddPoints(int points)
    {
        TotalPoints += points;
    }

    public void DisplayStats()
    {
        Console.WriteLine($"Total Points: {TotalPoints}, Level: {Level}, Title: {Title}");
    }
}
