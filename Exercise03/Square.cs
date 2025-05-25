namespace Exercise03
{
    public class Square : Shape
    {
        public Square(double side)
        {
            Height = side;
            Width = side;
        }

        public override double Area => Height * Width;
    }
}
