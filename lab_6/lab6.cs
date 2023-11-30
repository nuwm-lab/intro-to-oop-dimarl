using System;

namespace InterfacesAndAbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            var quad = CreateQuadrangle();
            DisplayFigureData(quad);

            var triangle = CreateTriangle();
            DisplayFigureData(triangle);
        }

        static Quadrangle CreateQuadrangle()
        {
            var quad = new Quadrangle();
            var verticesQuad = GetVertices(quad.NumberOfSides, new string[] { "A", "B", "C", "D" });

            quad.SetVertices(verticesQuad);
            quad.CalculateSides();
            quad.CalculateArea();

            return quad;
        }

        static Triangle CreateTriangle()
        {
            var triangle = new Triangle();
            var verticesTriangle = GetVertices(triangle.NumberOfSides, new string[] { "A", "B", "C" });

            triangle.SetVertices(verticesTriangle);
            triangle.CalculateSides();
            triangle.CalculateArea();

            return triangle;
        }

        static double[,] GetVertices(int sides, string[] names)
        {
            var vertices = new double[sides, 2];
            for (int i = 0; i < sides; i++)
            {
                Console.Write($"Vertex {names[i]}: x = ");
                if (!double.TryParse(Console.ReadLine(), out double x))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Environment.Exit(0);
                }

                Console.Write($"Vertex {names[i]}: y = ");
                if (!double.TryParse(Console.ReadLine(), out double y))
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                    Environment.Exit(0);
                }

                vertices[i, 0] = x;
                vertices[i, 1] = y;
            }
            return vertices;
        }

        static void DisplayFigureData(Figure figure)
        {
            Console.WriteLine("Figure Data:");
            figure.ShowData();
        }
    }

    abstract class Figure
    {
        public double Area { get; protected set; }
        public abstract int NumberOfSides { get; }
        public abstract double CalculateArea();
        public abstract void CalculateSides();
        public abstract void SetVertices(double[,] vertices);
        public abstract void ShowData();
    }

    class Triangle : Figure
    {
        private double[,] Vertices { get; set; }
        private double[] LengthsOfSides { get; set; }
        private string[] NamesOfSides = { "AB", "BC", "AC" };
        private string[] NamesOfVertices = { "A", "B", "C" };
        public override int NumberOfSides { get { return 3; } }

        public override void SetVertices(double[,] vertices)
        {
            Vertices = vertices;
        }

        public override double CalculateArea()
        {
            if (Vertices == null || LengthsOfSides == null)
            {
                Console.WriteLine("Operation isn't available!");
                return 0;
            }
            else
            {
                double perimeter = 0;
                for (int i = 0; i < NumberOfSides; i++)
                {
                    perimeter += LengthsOfSides[i];
                }
                Area = Math.Sqrt((perimeter / 2) * (perimeter / 2 - LengthsOfSides[0]) * (perimeter / 2 - LengthsOfSides[1]) * (perimeter / 2 - LengthsOfSides[2]));
                return Area;
            }
        }

        public override void CalculateSides()
        {
            if (Vertices == null)
            {
                Console.WriteLine("The coordinates are not set!");
            }
            else
            {
                LengthsOfSides = new double[NumberOfSides];
                LengthsOfSides[0] = CalculateLength(Vertices[0, 0], Vertices[0, 1], Vertices[1, 0], Vertices[1, 1]);
                LengthsOfSides[1] = CalculateLength(Vertices[1, 0], Vertices[1, 1], Vertices[2, 0], Vertices[2, 1]);
                LengthsOfSides[2] = CalculateLength(Vertices[2, 0], Vertices[2, 1], Vertices[0, 0], Vertices[0, 1]);
            }
        }

        private double CalculateLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public override void ShowData()
        {
            if (LengthsOfSides == null || Vertices == null)
            {
                Console.WriteLine("Operation isn't available!");
            }
            else
            {
                Console.WriteLine("---------------------------------------------");

                for (int i = 0; i < NumberOfSides; i++)
                {
                    Console.WriteLine($"{NamesOfVertices[i]}: x = {Vertices[i, 0]}, y = {Vertices[i, 1]}");
                }

                Console.WriteLine("---------------------------------------------");

                for (int i = 0; i < NumberOfSides; i++)
                {
                    Console.WriteLine($"{NamesOfSides[i]}: {LengthsOfSides[i]}");
                }

                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"Area: {Area}");
                Console.WriteLine("---------------------------------------------");
            }
        }
    }

    class Quadrangle : Figure
    {
        private double[,] Vertices { get; set; }
        private double[] LengthsOfSides { get; set; }
        private string[] NamesOfSides = { "AB", "BC", "CD", "AD" };
        private string[] NamesOfVertices = { "A", "B", "C", "D" };
        public override int NumberOfSides { get { return 4; } }

        public override void SetVertices(double[,] vertices)
        {
            Vertices = vertices;
        }

        public override void ShowData()
        {
            if (LengthsOfSides == null || Vertices == null)
            {
                Console.WriteLine("Operation isn't available!");
            }
            else
            {
                Console.WriteLine("---------------------------------------------");

                for (int i = 0; i < NumberOfSides; i++)
                {
                    Console.WriteLine($"{NamesOfVertices[i]}: x = {Vertices[i, 0]}, y = {Vertices[i, 1]}");
                }

                Console.WriteLine("---------------------------------------------");

                for (int i = 0; i < NumberOfSides; i++)
                {
                    Console.WriteLine($"{NamesOfSides[i]}: {LengthsOfSides[i]}");
                }

                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"Area: {Area}");
                Console.WriteLine("---------------------------------------------");
            }
        }

        public override double CalculateArea()
        {
            if (LengthsOfSides == null || Vertices == null)
            {
                Console.WriteLine("Operation isn't available!");
                return 0;
            }

            Area = LengthsOfSides[0] * LengthsOfSides[1];
            return Area;
        }

        public override void CalculateSides()
        {
            if (Vertices == null)
            {
                Console.WriteLine("Vertices are not set!");
            }
            else
            {
                LengthsOfSides = new double[NumberOfSides];

                LengthsOfSides[0] = CalculateLength(Vertices[0, 0], Vertices[0, 1], Vertices[1, 0], Vertices[1, 1]);
                LengthsOfSides[1] = CalculateLength(Vertices[1, 0], Vertices[1, 1], Vertices[2, 0], Vertices[2, 1]);
                LengthsOfSides[2] = CalculateLength(Vertices[2, 0], Vertices[2, 1], Vertices[3, 0], Vertices[3, 1]);
                LengthsOfSides[3] = CalculateLength(Vertices[3, 0], Vertices[3, 1], Vertices[0, 0], Vertices[0, 1]);
            }
        }

        private double CalculateLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
