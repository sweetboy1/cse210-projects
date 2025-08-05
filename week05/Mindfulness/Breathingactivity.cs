using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This helps you relax through slow breathing.") {}

    public override void Run()
    {
        StartMessage();
        DateTime end = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < end)
        {
            AnimatedBreathing("Breathe in", 3);
            AnimatedBreathing("Now breathe out", 3);
        }

        EndMessage();
    }

    private void AnimatedBreathing(string message, int seconds)
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.Write("\r" + message + new string('.', i) + "   ");
            Thread.Sleep(seconds * 1000 / 5);
        }
        Console.WriteLine();
    }
}
