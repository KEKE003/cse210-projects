using System;

namespace MindfulnessProgram
{
    public class BreathingActivity : Activity
    {
        public BreathingActivity() : base("Breathing Activity", "This Activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {  
        }

        public void Run()
        {
            DisplayStartingMessage();

            DateTime startTime = DateTime.Now;
            DateTime endTime = startTime.AddSeconds(GetDuration());

            while (DateTime.Now < endTime)
            {
                Console.Write("Breathe in...");
                ShowCountdown(4);
                Console.WriteLine();

                Console.Write("Breath out...");
                ShowCountdown(6);
                Console.WriteLine();
                Console.WriteLine();
            }

            DisplayEndingMessage();
        }
    }
}