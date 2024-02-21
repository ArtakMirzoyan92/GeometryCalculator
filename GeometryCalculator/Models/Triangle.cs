using GeometryCalculator.Interfase;

namespace GeometryCalculator.Models
{
    public class Triangle : ITriangle
    {
        public double SideA { get; }
        public double SideB { get; }
        public double SideC { get; }

        private const double Tolerance = 0.000001;

        public Triangle(double sideA, double sideB, double sideC)
        {
            ValidateSides(sideA, sideB, sideC);

            SideA = sideA;
            SideB = sideB;
            SideC = sideC;
        }

        void ValidateSides(double sideA, double sideB, double sideC)
        {
            if (sideA <= 0 || sideB <= 0 || sideC <= 0)
                throw new ArgumentException("The sides of a triangle cannot be negative.");

            if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
                throw new ArgumentException("The sum of any two sides of a triangle must be greater than the third side.");
        }

        public double CalculateArea()
        {
            double semiPerimeter = (SideA + SideB + SideC) / 2;
            return Math.Sqrt(semiPerimeter * (semiPerimeter - SideA) * (semiPerimeter - SideB) * (semiPerimeter - SideC));
        }

        public bool IsRightTriangle()
        {
            double[] sides = { SideA, SideB, SideC };
            Array.Sort(sides);
            return Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < Tolerance;
        }
    }
}
