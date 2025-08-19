using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2NickDamor
{
    public class Triangle : Shape
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }

        public Triangle(double a, double b, double c, double opacity)
            : base(ShapeTypes.Triangle, opacity)
        {
            A = a;
            B = b;
            C = c;
        }

        public override double Perimeter()
        {
            return A + B + C;
        }

        public override double Area()
        {
            double s = Perimeter() / 2;
            return Math.Sqrt(s * (s - A) * (s - B) * (s - C));
        }
    }
}
