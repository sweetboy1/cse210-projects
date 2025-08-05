using System;
using System.Collections.Generic;
using System.IO;

public class GratitudeActivity : Activity
{
    public GratitudeActivity() : base("Gratitude Activity", "This helps you record things you're thankful for.") {}

    public override void Run()
    {
        StartMessage();
        Console.WriteLine("List things you're grateful for. Press Enter after each. Leave blank to finish.");

        List<string> entries = new List<string>();
        while (true)
        {
            Console.Write("> ");
            string entry = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(entry)) break;
            entries.Add(entry);
        }

        File.AppendAllLines("gratitude.txt", entries);
        Console.WriteLine($"\nSaved {entries.Count} gratitude items.");
        EndMessage();
    }
}
