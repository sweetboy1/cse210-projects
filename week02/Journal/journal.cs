#nullable enable
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace JournalApp
{
    public class Journal
    {
        private List<Entry> _entries = new();
        private readonly List<string> _prompts = new()
        {
            "What are you grateful for today?",
            "Describe a challenging moment you faced recently.",
            "What is one goal you want to achieve this week?",
            "Write about someone who inspired you today.",
            "Reflect on a recent happy memory."
        };

        public string GetRandomPrompt()
        {
            var rand = new Random();
            return _prompts[rand.Next(_prompts.Count)];
        }

        public void AddEntry(string prompt, string text)
        {
            if (string.IsNullOrWhiteSpace(text))
            {
                Console.WriteLine("Cannot add an empty journal entry.");
                return;
            }
            _entries.Add(new Entry(DateTime.Now, prompt, text));
            Console.WriteLine("Entry added successfully.");
        }

        public void EditEntry(int index, string newText)
        {
            if (index < 0 || index >= _entries.Count)
            {
                Console.WriteLine("Invalid entry number.");
                return;
            }
            if (string.IsNullOrWhiteSpace(newText))
            {
                Console.WriteLine("Cannot set an empty entry text.");
                return;
            }
            _entries[index].Text = newText;
            _entries[index].EntryDateTime = DateTime.Now;
            Console.WriteLine("Entry edited successfully.");
        }

        public void DeleteEntry(int index)
        {
            if (index < 0 || index >= _entries.Count)
            {
                Console.WriteLine("Invalid entry number.");
                return;
            }
            _entries.RemoveAt(index);
            Console.WriteLine("Entry deleted successfully.");
        }

        public void DisplayAllEntries()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("No journal entries to display.");
                return;
            }

            for (int i = 0; i < _entries.Count; i++)
            {
                Console.WriteLine($"Entry #{i + 1}:\n{_entries[i]}");
            }
        }

        public void SearchEntries(string keyword)
        {
            var matches = _entries
                .Select((entry, index) => (entry, index))
                .Where(pair => pair.entry.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase)
                            || pair.entry.Text.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matches.Count == 0)
            {
                Console.WriteLine("No matching entries found.");
                return;
            }

            Console.WriteLine($"Found {matches.Count} matching entries:");
            foreach (var (entry, index) in matches)
            {
                Console.WriteLine($"Entry #{index + 1}:\n{entry}");
            }
        }

        public void SaveToFile(string filename)
        {
            try
            {
                using StreamWriter writer = new(filename);
                foreach (var entry in _entries)
                {
                    writer.WriteLine(entry.EntryDateTime.ToString("o"));
                    writer.WriteLine(entry.Prompt);
                    writer.WriteLine(entry.Text.Replace(Environment.NewLine, "\\n"));
                    writer.WriteLine("---");
                }
                Console.WriteLine($"Journal saved to {filename}.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving journal: {ex.Message}");
            }
        }

        public void LoadFromFile(string filename)
        {
            try
            {
                if (!File.Exists(filename))
                {
                    Console.WriteLine("File does not exist.");
                    return;
                }

                var lines = File.ReadAllLines(filename);
                _entries.Clear();

                for (int i = 0; i < lines.Length; )
                {
                    if (i + 3 >= lines.Length) break;

                    DateTime entryDateTime = DateTime.Parse(lines[i]);
                    string prompt = lines[i + 1];
                    string text = lines[i + 2].Replace("\\n", Environment.NewLine);
                    _entries.Add(new Entry(entryDateTime, prompt, text));

                    i += 4;
                }

                Console.WriteLine($"Journal loaded from {filename}. Entries count: {_entries.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error loading journal: {ex.Message}");
            }
        }

        public int CountEntries() => _entries.Count;
    }
}
