using System;
using System.Collections.Generic;

namespace MindfulnessProgram
{
    public class ListingActivity : Activity
    {
        private List<string> _prompts;
        private List<string> _unusedPrompts;

        public ListingActivity() : base("ListingActivity", "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt peace or inspiration this month?",
                "Who are some of your personal heroes?"
            };

            _unusedPrompts = new List<string>(_prompts);
        }

        public void Run()
        {
            DisplayStartingMessage();
            Console.WriteLine("List as many items as you can in response to the following prompt:");
            Console.WriteLine($"---{GetRandomPrompt()}---");
            Console.Write("You may begin in:");
            ShowCountdown(5);
            Console.WriteLine();

            List<string> itemsList = new List<string>();
            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(GetDuration());

            while (DateTime.Now < endTime)
            {
                Console.Write(">");
                string input = Console.ReadLine();

                if (!string.IsNullOrWhiteSpace(input))
                {
                    itemsList.Add(input);
                }
            }

            Console.WriteLine($"You listed {itemsList.Count} items!");
            DisplayEndingMessage();
        }

        private string GetRandomPrompt()
        {
            if (_unusedPrompts.Count == 0)
            {
                _unusedPrompts = new List<string>(_prompts);
            }

            Random rand = new Random();
            int index = rand.Next(_unusedPrompts.Count);
            string prompt = _unusedPrompts[index];

            _unusedPrompts.RemoveAt(index);
            
            return prompt;
        }
    }
}