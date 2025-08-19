using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2NickDamor
{
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public Circle(double radius, double opacity)
            : base(ShapeTypes.Circle, opacity)
        {
            Radius = radius;
        }

        public override double Area()
        {
            return Math.PI * Radius * Radius;
        }

        public override double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
