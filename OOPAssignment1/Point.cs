using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment1
{
    internal struct Point
    {
        private double x;
        private double y;

        public Point(double _x, double _y)
        {
            x = _x;
            y = _y;
        }

        public double X { get { return x; } set {  x = value; } }
        public double Y { get { return y; } set { y = value; } }

    }
}
