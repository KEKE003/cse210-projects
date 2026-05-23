using System;

namespace JournalProgram
{
    class Program
    {
        /* 1. Added two more prompts.
         * 2. Used ~/~ during the file saving.
         * 3. Made the program ask about user's mood.
         */
        static void Main(string[] args)
        {
            Journal journal = new Journal();
            string choice = "";

            Console.WriteLine("Welcome to the Journal Program!");

            while (choice != "5")
            {
                Console.WriteLine("Please select one of the following choices:");
                Console.WriteLine("1. Write a new entry");
                Console.WriteLine("2. Display the journal");
                Console.WriteLine("3. Save the journal to a file");
                Console.WriteLine("4. Load the journal from a file");
                Console.WriteLine("5. Quit");
                Console.Write("What would you like to do? ");

                choice = Console.ReadLine();
        
                if(choice == "1")
                {
                    string prompt = journal.GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("> ");
                    string response = Console.ReadLine() ;

                    Console.Write("How is your mood today? ");
                    string mood = Console.ReadLine();

                    string dateText = DateTime.Now.ToShortDateString();
                    Entry newEntry = new Entry(dateText, prompt, response, mood);

                    journal.AddEntry(newEntry);
                    Console.WriteLine("Entry recorded!");
                }
                else if (choice == "2")
                {
                    journal.DisplayAll();
                }
                else if (choice == "3")
                {
                    Console.Write("What is the filename? ");
                    string saveFile = Console.ReadLine();
                    journal.SaveToFile(saveFile);
                }
                else if (choice == "4")
                {
                    Console.Write("What is the filename? ");
                    string loadFile = Console.ReadLine();
                    journal.LoadFromFile(loadFile);
                }
                else if (choice == "5")
                {
                    Console.WriteLine("Thank you for using the Journal Program. Goodbye!");
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please pick a number from 1 to 5.");
                }
            }

        }
    }
}    