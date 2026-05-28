using System;
using System.Collections.Generic;

namespace ScriptureMemorizer
{
    // CREATIVITY:
    // The program works with a scripture library, and chooses scriptures at random for the user .
    class Program
    {
        static void Main(string[] args)
        {
            List<Scripture> scriptureLibrary = new List<Scripture>
            {
                new Scripture(new Reference("John", 3, 16), "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not parish, but have everlasting life."),
                new Scripture(new Reference("Proverbs", 3, 5-6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding.In all thy ways acknowledge him, and he shall direct thy paths."),
                new Scripture(new Reference("Philippians", 4, 13), "I can do all things through Christ which strengtheneth me."),
                new Scripture(new Reference("Joshua", 1, 9), "Have not I commanded thee? Be strong and of good courage; be not afraid, neither be thou dismayed: for I the Lord thy God is with thee whithersoever thou goest.")
            };

            Random random = new Random();
            Scripture currentScripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

            while (true)
            {
                Console.Clear();
                Console.WriteLine(currentScripture.GetDisplayText());
                Console.WriteLine();

                if (currentScripture.IsCompletelyHidden())
                {
                    Console.WriteLine("The entire scripture has been hidden.");
                    break;
                }

                Console.WriteLine("Press Enter to hide more words, or type 'quit' to exit: ");
                string input = Console.ReadLine();

                if (input.Trim().ToLower() == "quit")
                {
                    break;
                }

                currentScripture.HideRandomWords(3);
            }

        }
    }
}