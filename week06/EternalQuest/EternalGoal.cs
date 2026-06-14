using System;

namespace EternalQuest
{
    public class EternalGoal : Goal
    {
        public override bool IsComplete() => false;
        public EternalGoal (string name, string description, int points) : base(name, description, points){}
        public override int RecordEvent()
        {
            return GetPoints;   
        }
        public override string GetStringRepresentation()
        {
            return ($"EternalGoal: {GetName}, {GetDescription}, {GetPoints}");
        }
    }
}