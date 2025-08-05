using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static List<Goal> goals = new List<Goal>();
    static LevelSystem levelSystem = new LevelSystem();

    static void Main()
    {
        LoadData(); // Load if goals.txt exists

        bool running = true;
        while (running)
        {
            Console.Clear();
            Console.WriteLine("=== Eternal Quest ===");
            levelSystem.DisplayStats();
            Console.WriteLine("1. Create Goal\n2. List Goals\n3. Record Event\n4. Save\n5. Load\n6. Quit");
            Console.Write("Choose: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveData(); break;
                case "5": LoadData(); break;
                case "6": running = false; break;
            }
        }
    }

    static void CreateGoal()
    {
        Console.WriteLine("1. Simple\n2. Eternal\n3. Checklist");
        string type = Console.ReadLine();
        Console.Write("Name: ");
        string name = Console.ReadLine();
        Console.Write("Description: ");
        string desc = Console.ReadLine();
        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        switch (type)
        {
            case "1":
                goals.Add(new SimpleGoal(name, desc, points));
                break;
            case "2":
                goals.Add(new EternalGoal(name, desc, points));
                break;
            case "3":
                Console.Write("Target Count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Bonus: ");
                int bonus = int.Parse(Console.ReadLine());
                goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
                break;
        }
    }

    static void ListGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].GetStatus()}");
        }
        Console.WriteLine("Press enter to continue...");
        Console.ReadLine();
    }

    static void RecordEvent()
    {
        Console.WriteLine("Which goal did you accomplish?");
        for (int i = 0; i < goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {goals[i].Name}");
        }

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= goals.Count)
        {
            int earned = goals[index - 1].RecordEvent();
            levelSystem.AddPoints(earned);
            Console.WriteLine($"You earned {earned} points!");
        }
        else
        {
            Console.WriteLine("Invalid selection.");
        }
        Console.WriteLine("Press enter...");
        Console.ReadLine();
    }

    static void SaveData()
    {
        using (StreamWriter sw = new StreamWriter("goals.txt"))
        {
            sw.WriteLine(levelSystem.TotalPoints);
            foreach (Goal goal in goals)
                sw.WriteLine(goal.GetSaveString());
        }
        Console.WriteLine("Goals saved!");
        Console.ReadLine();
    }

    static void LoadData()
    {
        if (File.Exists("goals.txt"))
        {
            goals.Clear();
            string[] lines = File.ReadAllLines("goals.txt");
            levelSystem = new LevelSystem();
            levelSystem.AddPoints(int.Parse(lines[0]));

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split('|');
                switch (parts[0])
                {
                    case "SimpleGoal":
                        goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3])) { });
                        if (bool.Parse(parts[4]))
                            goals[^1].RecordEvent(); // mark as complete
                        break;
                    case "EternalGoal":
                        goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
                        break;
                    case "ChecklistGoal":
                        var cg = new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]));
                        for (int j = 0; j < int.Parse(parts[6]); j++) cg.RecordEvent();
                        goals.Add(cg);
                        break;
                }
            }
        }
    }
}
