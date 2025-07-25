using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OOPAssignment2
{
    #region 1. Define 3D Point Class and the basic Constructors (use chaining in constructors).
    internal class Point3D : IComparable<Point3D>, ICloneable
    {
		private int x;

		public int X
		{
			get { return x; }
			set { x = value; }
		}

		private int y;

		public int Y
		{
			get { return y; }
			set { y = value; }
		}

		private int z;

		public int Z
		{
			get { return z; }
			set { z = value; }
		}

		public Point3D(int _x, int _y, int _z) {
			x= _x;
			y= _y;
			z= _z;
		}

		public Point3D(int _x, int _y): this(_x, _y,0) { 
	
		}

        public Point3D(int _x) : this(_x, 0, 0)
        {

        }

        public Point3D() : this(0, 0, 0)
        {

        }
        public override string ToString()
        {
            return $"Point Coordinates: ({x}, {y}, {z})";
        }

        public static bool operator == (Point3D p1, Point3D p2)
        {
            if (p1 is null || p2 is null)
                return false;

            return p1.x == p2.x && p1.y == p2.y && p1.z == p2.z;
        }

        public static bool operator !=(Point3D p1, Point3D p2)
        {
            return !(p1 == p2);
        }

        public static bool operator >(Point3D p1, Point3D p2)
        {
            return p1?.x > p2?.x && p1?.y > p2?.y;
        }

        public static bool operator <(Point3D p1, Point3D p2)
        {
            return p1?.x < p2?.x && p1?.y < p2?.y;
        }
        public int CompareTo(Point3D other)
        {
            if (this > other) return 1;
            if (this < other) return -1;
            return 0;
        }
        public object Clone()
        {
            return new Point3D(this.x, this.y, this.z);
        }



    }
    #endregion
}
