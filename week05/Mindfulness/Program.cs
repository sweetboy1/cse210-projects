using System;
using System.IO;

class Program
{
    static void Main()
    {
        if (File.Exists("log.txt"))
        {
            Console.WriteLine("Welcome back! Here's your session history:\n");
            Console.WriteLine(File.ReadAllText("log.txt"));
        }

        int choice;
        do
        {
            Console.WriteLine("\n--- Mindfulness Menu ---");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Gratitude Activity (Bonus)");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: new BreathingActivity().Run(); break;
                case 2: new ReflectionActivity().Run(); break;
                case 3: new ListingActivity().Run(); break;
                case 4: new GratitudeActivity().Run(); break;
                case 5:
                    Console.WriteLine($"\nThank you! You completed {Activity.TotalSessions} session(s) totaling {Activity.TotalTime} seconds.");
                    break;
                default: Console.WriteLine("Invalid option."); break;
            }
        } while (choice != 5);
    }
}
