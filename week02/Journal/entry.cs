#nullable enable
using System;

namespace JournalApp
{
    public class Entry
    {
        public DateTime EntryDateTime { get; set; }
        public string Prompt { get; set; }
        public string Text { get; set; }

        public Entry(DateTime entryDateTime, string prompt, string text)
        {
            EntryDateTime = entryDateTime;
            Prompt = prompt;
            Text = text;
        }

        public override string ToString()
        {
            return $"[{EntryDateTime:yyyy-MM-dd HH:mm:ss}] Prompt: {Prompt}\nEntry: {Text}\n";
        }
    }
}
