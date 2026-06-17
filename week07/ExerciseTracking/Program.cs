using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the ExerciseTracking Program!");
            List<Activity> activities = new List<Activity>
            {
                new Running("03 Nov 2022", 30, 3.0),
                new Cycling("04 Nov 2022", 45, 15.0),
                new Swimming("05 Nov 2022", 40, 40)
            };
            
            Console.WriteLine("Exercise Tracking Summary: ");
            Console.WriteLine("============================");

            foreach (Activity activity in activities)
            {
                Console.WriteLine(activity.GetSummary());
            }
        }
    }
} 