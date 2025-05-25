using System;

namespace Exercise03
{
    public class Circle : Shape
    {
        public Circle(double radius)
        {
            Height = radius * 2;
            Width = radius * 2;
        }

        public override double Area => Math.PI * Math.Pow(Width / 2, 2);
    }
}
