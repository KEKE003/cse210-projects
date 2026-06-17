using System;
using System.Collections.Generic;

namespace ExerciseTracking
{
    public class Cycling : Activity
    {
        private double _speed;
        public Cycling (string date, double minutes, double speed) : base (date, minutes)
        {
            _speed = speed;
        }
        public override double GetDistance()
        {
            return (_speed / 60) * GetMinutes();
        }
        public override double GetSpeed()
        {
            return _speed;
        }
        public override double GetPace()
        {
            return 60 / _speed;
        }
        public override string GetSummary()
        {
            return $"{GetDate()} Cycling({GetMinutes()} min) - Distance: {GetDistance(): 0.0} km, Speed: {GetSpeed(): 0.0} kph, Pace: {GetPace(): 0.00} min per km";
        }
    }
}