using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment2P3
{
    internal class Duration
    {
        #region 1. Define Class Duration To include Three Attributes Hours, Minutes and Seconds.
        private int hours;

		public int Hours
		{
			get { return hours; }
			set { hours = value; }
		}

		private int minutes;

		public int Minutes
		{
			get { return minutes; }
			set { minutes = value; }
		}

		private int seconds;

		public int Seconds
		{
			get { return seconds; }
			set { seconds = value; }
		}
        #endregion

        #region 2. Override All System.Object Members (ToString, Equals,GetHasCode) .
        public override string ToString()
        {
            return $"Hours : {hours}, Minutes : {minutes}, Seconds : {seconds}";
        }

        public override bool Equals(object duration2)
        {
            if (duration2 is Duration d2)
            {
                return this.Hours == d2.Hours && this.Minutes == d2.Minutes && this.Seconds == d2.Seconds;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Hours, Minutes, Seconds);
        }
        #endregion

        #region 3. Define All Required Constructors

        public Duration (int _hours,int _minutes, int _seconds)
		{
			hours = _hours;
			minutes = _minutes;
			seconds = _seconds;
            adjustTime();
		}

        public Duration(int _seconds) : this(_seconds / 3600, (_seconds % 3600) / 60, _seconds % 60)
        {
        }
        public Duration() : this(0,0,0)
        {
        }
        #endregion

        #region 4. Implement All required Operators overloading
        public static Duration operator +(Duration d1, Duration d2)
        {
            return new Duration(
                (d1?.Hours ?? 0) + (d2?.Hours ?? 0),
                (d1?.Minutes ?? 0) + (d2?.Minutes ?? 0),
                (d1?.Seconds ?? 0) + (d2?.Seconds ?? 0)
            );
        }
        public static Duration operator +(int seconds, Duration d2)
        {
            Duration duration = new Duration(seconds);
            return new Duration(
                (duration?.Hours ?? 0) + (d2?.Hours ?? 0),
                (duration?.Minutes ?? 0) + (d2?.Minutes ?? 0),
                (duration?.Seconds ?? 0) + (d2?.Seconds ?? 0)
            );
        }

        public static Duration operator +(Duration dur1, int seconds)
        {
            Duration duration = new Duration(seconds);
            return new Duration(
                (duration?.Hours ?? 0) + (dur1?.Hours ?? 0),
                (duration?.Minutes ?? 0) + (dur1?.Minutes ?? 0),
                (duration?.Seconds ?? 0) + (dur1?.Seconds ?? 0)
            );
        }

        public static Duration operator -(Duration d1, Duration d2)
        {
            return new Duration(
                (d1?.Hours ?? 0) - (d2?.Hours ?? 0),
                (d1?.Minutes ?? 0) - (d2?.Minutes ?? 0),
                (d1?.Seconds ?? 0) - (d2?.Seconds ?? 0)
            );
        }

        public static Duration operator ++(Duration dur)
        {
            return new Duration
            (
                dur?.Hours ?? 0,
                (dur?.Minutes ?? 0)+ 1,
                dur?.Seconds ?? 0

            );
        }

        public static Duration operator --(Duration dur)
        {
            return new Duration
            (
                dur?.Hours ?? 0,
                (dur?.Minutes ?? 0) - 1,
                dur?.Seconds ?? 0

            );
        }

        public static bool operator >(Duration d1, Duration d2)
        {
            if (d1.Hours > d2.Hours)
                return true;
            if (d1.Hours < d2.Hours)
                return false;
            if (d1.Minutes > d2.Minutes)
                return true;
            if (d1.Minutes < d2.Minutes)
                return false;
            return d1.Seconds > d2.Seconds;
        }

        public static bool operator <(Duration d1, Duration d2)
        {
            if (d1.Hours < d2.Hours)
                return true;
            if (d1.Hours > d2.Hours)
                return false;
            if (d1.Minutes < d2.Minutes)
                return true;
            if (d1.Minutes > d2.Minutes)
                return false;
            return d1.Seconds < d2.Seconds;
        }

        public static bool operator >=(Duration d1, Duration d2)
        {
            return !(d1 < d2);
        }

        public static bool operator <=(Duration d1, Duration d2)
        {
            return !(d1 > d2);
        }

        public static explicit operator DateTime(Duration dur)
        {
            return DateTime.Today.AddHours(dur.Hours).AddMinutes(dur.Minutes).AddSeconds(dur.Seconds);
        }

        #endregion

        private void adjustTime()
        {
            if (seconds >= 60)
            {
                minutes += seconds / 60;
                seconds %= 60;
            }

            else if (seconds < 0)
            {
                int borrow = (Math.Abs(seconds) + 59) / 60;
                minutes -= borrow;
                seconds += borrow * 60;
            }

            if (minutes >= 60)
            {
                hours += minutes / 60;
                minutes %= 60;
            }

            else if (minutes < 0)
            {
                int borrow = (Math.Abs(minutes) + 59) / 60;
                hours -= borrow;
                minutes += borrow * 60;
            }
        }






    }
}
