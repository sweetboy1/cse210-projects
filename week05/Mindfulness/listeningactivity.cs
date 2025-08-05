using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "List things that make you happy.",
        "List moments you felt proud.",
        "List people who influenced you positively."
    };

    private List<string> _usedPrompts = new List<string>();

    public ListingActivity() : base("Listing Activity", "This helps you list positive elements in your life.") {}

    public override void Run()
    {
        StartMessage();

        string prompt = GetUniqueItem(_prompts, _usedPrompts);
        Console.WriteLine($"\n--- {prompt} ---");
        Console.WriteLine("You may begin listing:");

        DateTime end = DateTime.Now.AddSeconds(_duration);
        int count = 0;
        while (DateTime.Now < end)
        {
            Console.Write("> ");
            Console.ReadLine();
            count++;
        }

        Console.WriteLine($"You listed {count} items.");
        EndMessage();
    }

    private string GetUniqueItem(List<string> source, List<string> used)
    {
        if (used.Count == source.Count)
            used.Clear();

        string item;
        Random rand = new Random();
        do
        {
            item = source[rand.Next(source.Count)];
        } while (used.Contains(item));

        used.Add(item);
        return item;
    }
}
