using GeometryCalculator.Interfase;

namespace GeometryCalculator.Models
{
    public class Triangle : ITriangle
    {
        double A, B, C;

        public Triangle(double sideA, double sideB, double sideC)
        {
            ValidateSides(sideA, sideB, sideC);

            A = sideA;
            B = sideB;
            C = sideC;
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
            double P = (A + B + C) / 2;
            return Math.Sqrt(P * (P - A) * (P - B) * (P - C));
        }

        public bool IsRightTriangle()
        {
            double[] sides = { A, B, C };
            Array.Sort(sides);
            return Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < 0.000001;
        }
    }
}
