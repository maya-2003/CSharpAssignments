using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace OOPAssignment1
{
    #region 2- Develop a Class to represent the Hiring Date Data: consisting of fields to hold the day, month and Years.

    internal class HireDate
    {
        private int day;
        private int month;
        private int year;

        public HireDate(int day, int month, int year)
        {
            this.day = day;
            this.month = month;
            this.year = year;
        }
        public int Day {  get { return day; } set {  day = value; } }
        public int Month { get { return month; } set { month = value; } }
        public int Year { get { return year; } set { year = value; } }
    }
    #endregion
}
