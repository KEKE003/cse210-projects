using System;

namespace JournalProgram
{

    public class Entry (string date, string prompt, string response, string mood)
    {
        public string _date = date;
        public string _promptText = prompt;
        public string _entryText = response;
        public string _mood = mood;

        public void Display()
        {
           Console.WriteLine($"date: {_date} - prompt: {_promptText}");
           Console.WriteLine($"{_entryText}");
           Console.WriteLine($"mood: {_mood}");
           Console.WriteLine();
        }
    }
}