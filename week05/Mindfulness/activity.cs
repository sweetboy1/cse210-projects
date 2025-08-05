using System;
using System.Threading;

public abstract class Activity
{
    protected string _activityName;
    protected string _description;
    protected int _duration;

    public static int TotalSessions = 0;
    public static int TotalTime = 0;

    public Activity(string name, string description)
    {
        _activityName = name;
        _description = description;
    }

    public void StartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_activityName}.");
        Console.WriteLine(_description);
        Console.Write("\nEnter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        Spinner(3);
    }

    public void EndMessage()
    {
        Console.WriteLine($"\nWell done! You completed the {_activityName} for {_duration} seconds.");
        Spinner(3);
        TotalSessions++;
        TotalTime += _duration;

        File.AppendAllText("log.txt", $"{DateTime.Now}: Completed {_activityName} for {_duration} seconds\n");
    }

    protected void Spinner(int seconds)
    {
        string[] symbols = { "/", "-", "\\", "|" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(symbols[i++ % 4] + "\r");
            Thread.Sleep(250);
        }
    }

    public abstract void Run();
}
