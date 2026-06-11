using System;

namespace EternalQuest
{
    public abstract class Goal
    {
        private string _shortName;
        private string _description;
        private int _points;
        public Goal(string name, string description, int points)
        {
            _shortName = name;
            _description = description;
            _points = points;
        }
        public string GetName => _shortName;
        public string GetDescription => _description;
        public int GetPoints => _points;

        public abstract int RecordEvent();
        public abstract bool IsComplete();
        public virtual string GetDetailsString()
        {
            string statusSymbol = IsComplete() ? "[X]": "[]";
            return($"{statusSymbol} {_shortName}({_description})");
        }
        public abstract string GetStringRepresentation();
    }
    public class SimpleGoal : Goal
    {
        private bool _isComplete;
        public SimpleGoal (string name, string description, int points) : base(name, description, points)
        {
            _isComplete = false;
        }
        public override int RecordEvent()
        {
            if (! _isComplete)
            {
                _isComplete = true;
                return GetPoints;
            }
            return 0;
        }
        public override bool IsComplete() => _isComplete;
        public override string GetStringRepresentation()
        {
            return ($"Simple Goal: {GetName}, {GetDescription}, {GetPoints}, {_isComplete} ");
        }
    }
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