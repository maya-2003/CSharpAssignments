using OOPAssignment3.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPAssignment3.Classes
{
    internal class Rectangle : IRectangle
    {

        public Rectangle(double w,double h)
        {
            Width = w;  
            Height = h;

        }

        public Rectangle():this(0,0) { }


        public double Area { get { return Width * Height; } }

        public double Width { get; set; }
        public double Height { get ; set; }

        public void DisplayShapeInfo()
        {
            Console.WriteLine($"Rectangle Info: Area = {Area} | Width = {Width} | Height = {Height}");
        }
    }
}
