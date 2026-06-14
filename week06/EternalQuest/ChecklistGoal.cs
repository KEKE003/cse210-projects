using System;

namespace EternalQuest
{
    public class ChecklistGoal : Goal
    {
        private int _amountCompleted;
        private int _target;
        private int _bonus;
        public ChecklistGoal (string name, string description, int points, int target, int bonus) : base(name, description, points)
        {
            _amountCompleted = 0;
            _target = target;
            _bonus = bonus;
        }
        public override int RecordEvent()
        {
            if (IsComplete()) return 0;

            _amountCompleted++;
            if (_amountCompleted == _target)
            {
                return GetPoints + _bonus;
            }
            return GetPoints;
        }
        public void LoadProgress()
        {
            if (_amountCompleted < _target) _amountCompleted++;
        }
        public override bool IsComplete() => _amountCompleted >= _target;
        public override string GetDetailsString()
        {
            string statusSymbol = IsComplete() ? "[X]" : "[]";
            return ($"{statusSymbol} {GetName}({GetDescription} -- currently completed: {_amountCompleted} / {_target}");
        }
        public override string GetStringRepresentation()
        {
            return ($"ChecklistGoal: {GetName}, {GetDescription}, {GetPoints}, {_target}, {_amountCompleted}");
        }
    }
}