#nullable enable
using System;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal journal = new();
            string filename = "journal.txt";

            Console.WriteLine("Welcome to the Journal App!");
            bool running = true;

            while (running)
            {
                Console.WriteLine("\nMenu:");
                Console.WriteLine("1. Write new journal entry");
                Console.WriteLine("2. Display all entries");
                Console.WriteLine("3. Edit an entry");
                Console.WriteLine("4. Delete an entry");
                Console.WriteLine("5. Search entries");
                Console.WriteLine("6. Save journal");
                Console.WriteLine("7. Load journal");
                Console.WriteLine("8. Exit");
                Console.Write("Choose an option: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        string prompt = journal.GetRandomPrompt();
                        Console.WriteLine($"Prompt: {prompt}");
                        Console.Write("Write your entry: ");
                        string? entryText = Console.ReadLine();
                        journal.AddEntry(prompt, entryText ?? "");
                        break;

                    case "2":
                        journal.DisplayAllEntries();
                        break;

                    case "3":
                        if (journal.CountEntries() == 0)
                        {
                            Console.WriteLine("No entries to edit.");
                            break;
                        }
                        journal.DisplayAllEntries();
                        Console.Write("Enter the entry number to edit: ");
                        if (int.TryParse(Console.ReadLine(), out int editIndex))
                        {
                            editIndex -= 1;
                            Console.Write("Enter new text: ");
                            string? newText = Console.ReadLine();
                            journal.EditEntry(editIndex, newText ?? "");
                        }
                        else
                        {
                            Console.WriteLine("Invalid number.");
                        }
                        break;

                    case "4":
                        if (journal.CountEntries() == 0)
                        {
                            Console.WriteLine("No entries to delete.");
                            break;
                        }
                        journal.DisplayAllEntries();
                        Console.Write("Enter the entry number to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteIndex))
                        {
                            deleteIndex -= 1;
                            journal.DeleteEntry(deleteIndex);
                        }
                        else
                        {
                            Console.WriteLine("Invalid number.");
                        }
                        break;

                    case "5":
                        Console.Write("Enter keyword to search: ");
                        string? keyword = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(keyword))
                        {
                            journal.SearchEntries(keyword);
                        }
                        else
                        {
                            Console.WriteLine("Keyword cannot be empty.");
                        }
                        break;

                    case "6":
                        journal.SaveToFile(filename);
                        break;

                    case "7":
                        journal.LoadFromFile(filename);
                        break;

                    case "8":
                        running = false;
                        Console.WriteLine("Exiting the Journal App. Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid option, try again.");
                        break;
                }
            }
        }
    }
}
