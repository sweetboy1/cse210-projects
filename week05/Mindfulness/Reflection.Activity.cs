using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    private List<string> _prompts = new List<string> {
        "Think of a time you were truly at peace.",
        "Recall a moment of personal victory.",
        "Think about a time you helped someone.",
        "Reflect on something you overcame."
    };

    private List<string> _questions = new List<string> {
        "Why was this moment meaningful?",
        "What did you learn from it?",
        "Would you relive it again?",
        "How can this shape your future?"
    };

    private List<string> _usedPrompts = new List<string>();
    private List<string> _usedQuestions = new List<string>();

    public ReflectionActivity() : base("Reflection Activity", "This activity helps you reflect on meaningful experiences.") {}

    public override void Run()
    {
        StartMessage();

        string prompt = GetUniqueItem(_prompts, _usedPrompts);
        Console.WriteLine($"\n--- {prompt} ---\nThink about it...");
        Spinner(3);

        DateTime end = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < end)
        {
            string question = GetUniqueItem(_questions, _usedQuestions);
            Console.Write($"> {question} ");
            Spinner(5);
            Console.WriteLine();
        }

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
