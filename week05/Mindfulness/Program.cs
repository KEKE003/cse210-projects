using System;

/* ========CREATIVITY:
1.Enhanced Random Poll Tracking. The ReflectionActivity.cs and the ListingActivity.cs have been upgraded to not repeat any prompt or question in a session.===========================*/

namespace MindfulnessProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mindfulness Program!");
            string choice = "";

            while (choice !="4")
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("1.Start Breathing Activity");
                Console.WriteLine("2.Start Reflection Activity");
                Console.WriteLine("3.Start Listing Activity");
                Console.WriteLine("4.Quit");
                Console.Write("Select a choice from the menu:");
                choice = Console.ReadLine();

                switch (choice)
                {
                    case"1":
                    BreathingActivity breathing = new BreathingActivity();
                    breathing.Run();
                    break;

                    case"2":
                    ReflectionActivity reflection = new ReflectionActivity();
                    reflection.Run();
                    break;

                    case"3":
                    ListingActivity listing = new ListingActivity();
                    listing.Run();
                    break;

                    case"4":
                    Console.WriteLine("\nGoodBye! Remember to always be mindful.");
                    break;

                    default:
                    Console.WriteLine("\nInvalid option. Please press 'Enter' to try again.");
                    Console.ReadLine();
                    break;

                }
            }
        }
    }
}