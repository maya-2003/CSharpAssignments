using OOPAssignment3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment3.Classes
{
    internal class Circle : ICircle
    {
        public Circle(double radius)
        {
            Radius = radius;
        }
        public Circle(): this(0) { }
        public double Radius { get; set; }

        public double Area { get { return double.Pi * (Math.Pow(Radius,2)); } }

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Circle Info: Area = {Area} | radius = {Radius}");
        }
    }
}
