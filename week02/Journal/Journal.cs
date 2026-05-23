using System;
using System.Collections.Generic;
using System.IO;

namespace JournalProgram
{
    public class Journal
    {
        public List<Entry> _entries = new List<Entry>();
        private List<string>_prompts = new List<string>
        {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?", 
            "If I had one thing I could do over today, what would it be?",
            "What is something new I learned today?",
            "What is a valuable principle you learned from your scripture study today?",
            "Describe a small detail from your day that made you smile."
        };
        public string GetRandomPrompt()
        {
            Random random = new Random();
            int index = random.Next(_prompts.Count);
            return _prompts[index];
        }
        public void AddEntry(Entry newEntry)
        {
            _entries.Add(newEntry);
        }
        public void DisplayAll()
        {
            if (_entries.Count == 0)
            {
                Console.WriteLine("The journal is currently empty.");
                return;
            }

            Console.WriteLine("--- Journal Entries ---");
            foreach (Entry entry in _entries)
            {
                entry.Display();
            }
        }
        public void SaveToFile(string file)
        {
            using(StreamWriter writer = new StreamWriter(file))
            {
                foreach(Entry entry in _entries)
                {
                    writer.WriteLine($"{entry._date}~/~{entry._promptText}~/~{entry._entryText}");
                }
            }
            Console.WriteLine("Journal saved successfully!");
        }
        public void LoadFromFile(string file)
        {
            if (!File.Exists(file))
            {
                Console.WriteLine("Error: File not found.");
                return;
            }
            _entries.Clear();
            string[] lines = File.ReadAllLines(file);

            foreach (string line in lines)
            {
                string[] parts = line.Split(new string[] {"~/~"}, StringSplitOptions.None);
                if (parts.Length == 4)
                {
                    Entry loadedEntry = new Entry (parts[0], parts[1], parts[2], parts[3]);
                    _entries.Add(loadedEntry);
                }
            }
            Console.WriteLine("Journal loaded successfully!");
        }
    }
}