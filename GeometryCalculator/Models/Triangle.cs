using GeometryCalculator.Interfase;

namespace GeometryCalculator.Models
{
    public class Triangle : ITriangle
    {
        public double sideA, sideB, sideC;

        public Triangle(double sideA, double sideB, double sideC)
        {
            ValidateSides(sideA, sideB, sideC);

            this.sideA = sideA;
            this.sideB = sideB;
            this.sideC = sideC;
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
            double P = (sideA + sideB + sideC) / 2;
            return Math.Sqrt(P * (P - sideA) * (P - sideB) * (P - sideC));
        }

        public bool IsRightTriangle()
        {
            double[] sides = { sideA, sideB, sideC };
            Array.Sort(sides);
            return Math.Abs(Math.Pow(sides[2], 2) - (Math.Pow(sides[0], 2) + Math.Pow(sides[1], 2))) < 0.000001;
        }
    }
}
