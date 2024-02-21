using GeometryCalculator.Interfase;

namespace GeometryCalculator.Models
{
    public class Circle : IShape
    {
        public double Radius { get; }

        public Circle(double radius)
        {
            if (radius <= 0)
                throw new ArgumentException("The radius cannot be negative.");

            Radius = radius;
        }

        public double CalculateArea() => Math.PI * Math.Pow(Radius, 2);
       
    }
}
