using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace A2NickDamor
{
    public abstract class Shape
    {
        private static int nextId = 1;
        private readonly int shapeId;
        private double opacity;
        private readonly ShapeTypes shapeType;

        public int ShapeId => shapeId;
        public ShapeTypes ShapeType => shapeType;

        public double Opacity
        {
            get => opacity;
            set
            {
                if (value < 0 || value > 1)
                    throw new ArgumentOutOfRangeException("Opacity must be between 0 and 1.");
                opacity = value;
            }
        }

        public Shape(ShapeTypes type, double opacity)
        {
            this.shapeId = nextId++;
            this.shapeType = type;
            this.Opacity = opacity;
        }

        public abstract double Area();
        public abstract double Perimeter();
    }
}
