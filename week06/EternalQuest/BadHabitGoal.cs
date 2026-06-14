using System;

namespace EternalQuest
{
    public class BadHabitGoal : Goal
    {
        public BadHabitGoal(string name, string description, int points) : base (name, description, points){}
        public override int RecordEvent()
        {
            return -GetPoints;
        }
        public override bool IsComplete() => false;

        public override string GetDetailsString()
        {
            return ($"[-] {GetName}({GetDescription}) -- Deducts per slip up");
        }
        public override string GetStringRepresentation()
        {
           return ($"BadHabitGoal: {GetName}, {GetDescription}, {GetPoints}");
        }
    }
}