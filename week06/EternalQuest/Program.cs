using System;
using System.Collections.Generic;
using System.IO;

//========================CREATIVITY REPORT =========================================
// Added an automatic leveling system, users gain titles
// Created a BadHabitGoal class that helps track things the user wants to stop doing
//===================================================================================

namespace EternalQuest
{
    class Program
    {
        private static List<Goal> _goals = new List<Goal>();
        private static int _score = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the EternalQuest Project.");
            
            bool running = true;
            while (running)
            {
                Console.Clear();
                DisplayPlayerInfo();
                Console.WriteLine("\n--- Menu Options ---");
                Console.WriteLine("1. Create New Goal");
                Console.WriteLine("2. List Goals");
                Console.WriteLine("3. Save Goals");
                Console.WriteLine("4. Load Goals");
                Console.WriteLine("5. Record Event");
                Console.WriteLine("6. Quit");

                Console.Write("Select a choice from the menu: ");
                string choice = Console.ReadLine();
                switch(choice)
                {
                    case "1":
                    CreateGoal();
                    break;

                    case "2":
                    ListGoals();
                    break;

                    case "3":
                    SaveGoals();
                    break;

                    case "4": 
                    LoadGoals();
                    break;

                    case "5":
                    RecordEvent();
                    break;

                    case "6":
                    running = false;
                    break;

                    default: Console.WriteLine("Invalid choice. Press Enter to try again");
                    Console.ReadLine();
                    break;
                }
            }
        }
        static void DisplayPlayerInfo()
        {
            int level = (_score / 1000) + 1;
            string title = "Novice Adventurer";
            if (level >= 5) title = "Hero of Faith";
            if (level >= 10) title = "Ninja Unicorn";

            Console.WriteLine($"=== Eternal Quest ===");
            Console.WriteLine($"Current Score: {_score} points");
            Console.WriteLine($"Current Rank: Level {level} {title}");
        }
        static void CreateGoal()
        {
            Console.Clear();
            Console.WriteLine("--- Goal Types ---");
            Console.WriteLine("1.Simple Goal (One-time event)");
            Console.WriteLine("2.Eternal Goal (Repeats for points)");
            Console.WriteLine("3.Checklist Goal (Bonus points after multiple times)");
            Console.WriteLine("4.Bad Habit Goal (Negative points for slipping up)");

            Console.Write("Which type of goal would you like to create? ");
            string type = Console.ReadLine();

            Console.Write("What is the name of the goal? ");
            string name = Console.ReadLine();
            Console.Write("Give a short description of the goal: ");
            string description = Console.ReadLine();

            if (type == "4")
            {
                Console.Write("How many points are lost for this bad habit? ");
                int Points = int.Parse(Console.ReadLine());
                _goals.Add(new BadHabitGoal(name, description, Points));
                return;
            }
            Console.Write("What is the amount of points associated with this goal? ");
            int basePoints = int.Parse(Console.ReadLine());

            if (type == "1")
            {
                _goals.Add(new SimpleGoal(name, description, basePoints));
            }

            else if (type == "2")
            {
                _goals.Add(new EternalGoal(name, description, basePoints));
            }

            else if (type == "3")
            {
                Console.Write("What is the target of this goal? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int bonus = int.Parse(Console.ReadLine());
                _goals.Add(new ChecklistGoal(name, description, basePoints, target, bonus));
            }
        }
        static void ListGoals()
        {
            Console.Clear();
            Console.WriteLine("--- Your Goals ---");

            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals created yet.");
            }
            else
            {
                for (int i = 0; i < _goals.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{_goals[i].GetDetailsString()}");
                }
            }
            Console.WriteLine("\nPress Enter to return to the menu.");
            Console.ReadLine();
        }
        static void RecordEvent()
        {
            Console.Clear();
            Console.WriteLine("--- Record Event ---");

            if (_goals.Count == 0)
            {
                Console.WriteLine("No goals available to record.");
                Console.WriteLine("Press Enter to return to the menu.");
                return;
            }
            
            for (int i = 0; i < _goals.Count; i++)
            {
               Console.WriteLine($"{i + 1}.{_goals[i].GetName}");
            }
            Console.Write("Which goal did you accomplish? ");
            int index = int.Parse(Console.ReadLine()) - 1;
            
            if (index >= 0 && index < _goals.Count)
            {
                int pointsEarned = _goals[index].RecordEvent();
                _score += pointsEarned;

                if (pointsEarned > 0)
                
                    Console.WriteLine($"\nCongratulations! You earned {pointsEarned}points!");

                else if (pointsEarned < 0)
    
                    Console.WriteLine($"\nOuch! You have lost {Math.Abs(pointsEarned)}points. Keep trying, you've got this!");
            
                else
            
                    Console.WriteLine("\nThis goal is already completed!");
            }
            
            else
            {
                Console.WriteLine("Invalid Selection.");
            }
            Console.WriteLine("\nPress Enter to continue.");
            Console.ReadLine();
        }
        static void SaveGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();

            using (StreamWriter outputFile = new StreamWriter(filename))
            {
                outputFile.WriteLine(_score);

                foreach (Goal goal in _goals)
                {
                    outputFile.WriteLine(goal.GetStringRepresentation());
                }
            }
            Console.WriteLine("Goals saved successfully! Press Enter.");
            Console.ReadLine();
        }
        static void LoadGoals()
        {
            Console.Write("What is the filename for the goal file? ");
            string filename = Console.ReadLine();
            string content = File.ReadAllText(filename);
            Console.WriteLine(content);

            if (!File.Exists(filename))
            {
                Console.WriteLine("File not found! Press Enter.");
                Console.ReadLine();
                return;
            }
            _goals.Clear();
            string [] lines = File.ReadAllLines(filename);
            _score = int.Parse(lines[0]);

            for (int i = 1; i < lines.Length; i++)
            {
                string line = lines[i];
                string [] parts = line.Split(':');
                string type = parts[0];
                string [] details = parts[1].Split(',');

                if (type == "SimpleGoal")
                {
                    SimpleGoal sg = new SimpleGoal(details[0], details[1], int.Parse(details[2]));
                    if (bool.Parse(details[3])) sg.RecordEvent();
                    _goals.Add(sg);
                }
                else if (type == "EternalGoal")
                {
                    _goals.Add(new EternalGoal(details[0], details[1], int.Parse(details[2])));
                }
                else if (type == "ChecklistGoal")
                {
                    ChecklistGoal cg = new ChecklistGoal(details[0], details[1], int.Parse(details[2]), int.Parse(details[4]), int.Parse(details[3]));
                    int completedCount = int.Parse(details[0]);
                    for (int c = 0; c < completedCount; c++) cg.LoadProgress();
                    _goals.Add(cg);
                }
                else if (type == "BadHabitGoal")
                {
                    BadHabitGoal bg = new BadHabitGoal(details[0], details[1], int.Parse(details[2]));
                    _goals.Add(bg);
                }
            }
            Console.WriteLine("Goals loaded successfully! Press Enter.");
            Console.ReadLine();
        }
    }
}