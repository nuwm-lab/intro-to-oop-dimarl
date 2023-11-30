using System;

namespace InterfacesAndAbstractClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Quadrangle quad = new Quadrangle();
            var verticesQuad = new double[quad.NumberOfSides, 2];
            var nameOfVerticesQuad = new string[] { "A", "B", "C", "D" };

            for (int i = 0; i < quad.NumberOfSides; i++)
            {
                Console.Write($"Vertex {nameOfVerticesQuad[i]}: x = ");
                verticesQuad[i, 0] = double.Parse(Console.ReadLine());
                Console.Write($"Vertex {nameOfVerticesQuad[i]}: y = ");
                verticesQuad[i, 1] = double.Parse(Console.ReadLine());
            }

            quad.SetVertices(verticesQuad);
            quad.CalculateSides();
            quad.CalculateArea();
            quad.ShowData();

            Triangle trian = new Triangle();
            var verticesTriangle = new double[trian.NumberOfSides, 2];
            var nameOfVerticesTriangle = new string[] { "A", "B", "C" };

            for (int i = 0; i < trian.NumberOfSides; i++)
            {
                Console.Write($"Vertex {nameOfVerticesTriangle[i]}: x = ");
                verticesTriangle[i, 0] = double.Parse(Console.ReadLine());
                Console.Write($"Vertex {nameOfVerticesTriangle[i]}: y = ");
                verticesTriangle[i, 1] = double.Parse(Console.ReadLine());
            }

            trian.SetVertices(verticesTriangle);
            trian.CalculateSides();
            trian.CalculateArea();
            trian.ShowData();
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
        private double[,] vertices;
        private double[] lengthsOfSides;
        private string[] namesOfSides = { "AB", "BC", "AC" };
        private string[] namesOfVertices = { "A", "B", "C" };
        public override int NumberOfSides { get { return 3; } }

        public override void SetVertices(double[,] vertices)
        {
            this.vertices = new double[NumberOfSides, 2];
            for (int i = 0; i < NumberOfSides; i++)
            {
                this.vertices[i, 0] = vertices[i, 0];
                this.vertices[i, 1] = vertices[i, 1];
            }
        }

        public override double CalculateArea()
        {
            if (vertices == null || lengthsOfSides == null)
            {
                Console.WriteLine("Operation isn't available!");
                return 0;
            }
            else
            {
                double perimeter = 0;
                for (int i = 0; i < NumberOfSides; i++)
                {
                    perimeter += lengthsOfSides[i];
                }
                Area = Math.Sqrt((perimeter / 2) * (perimeter / 2 - lengthsOfSides[0]) * (perimeter / 2 - lengthsOfSides[1]) * (perimeter / 2 - lengthsOfSides[2]));
                return Area;
            }
        }

        public override void CalculateSides()
        {
            if (vertices == null)
            {
                Console.WriteLine("The coordinates are not set!");
            }
            else
            {
                lengthsOfSides = new double[NumberOfSides];
                lengthsOfSides[0] = CalculateLength(vertices[0, 0], vertices[0, 1], vertices[1, 0], vertices[1, 1]);
                lengthsOfSides[1] = CalculateLength(vertices[1, 0], vertices[1, 1], vertices[2, 0], vertices[2, 1]);
                lengthsOfSides[2] = CalculateLength(vertices[2, 0], vertices[2, 1], vertices[0, 0], vertices[0, 1]);
            }
        }

        private double CalculateLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }

        public override void ShowData()
        {
            if (lengthsOfSides == null || vertices == null)
            {
                Console.WriteLine("Operation isn't available!");
            }
            else
            {
                Console.WriteLine("---------------------------------------------");

                for (int i = 0; i < NumberOfSides; i++)
                {
                    Console.WriteLine($"{namesOfVertices[i]}: x = {vertices[i, 0]}, y = {vertices[i, 1]}");
                }

                Console.WriteLine("---------------------------------------------");

                for (int i = 0; i < NumberOfSides; i++)
                {
                    Console.WriteLine($"{namesOfSides[i]}: {lengthsOfSides[i]}");
                }

                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"Area: {Area}");
                Console.WriteLine("---------------------------------------------");
            }
        }
    }

    class Quadrangle : Figure
    {
        private double[,] vertices;
        private double[] lengthsOfSides;
        private string[] namesOfSides = { "AB", "BC", "CD", "AD" };
        private string[] namesOfVertices = { "A", "B", "C", "D" };
        public override int NumberOfSides { get { return 4; } }

        public override void SetVertices(double[,] vertices)
        {
            this.vertices = new double[NumberOfSides, 2];
            for (int i = 0; i < NumberOfSides; i++)
            {
                this.vertices[i, 0] = vertices[i, 0];
                this.vertices[i, 1] = vertices[i, 1];
            }
        }

        public override void ShowData()
        {
            if (lengthsOfSides == null || vertices == null)
            {
                Console.WriteLine("Operation isn't available!");
            }
            else
            {
                Console.WriteLine("---------------------------------------------");

                for (int i = 0; i < NumberOfSides; i++)
                {
                    Console.WriteLine($"{namesOfVertices[i]}: x = {vertices[i, 0]}, y = {vertices[i, 1]}");
                }

                Console.WriteLine("---------------------------------------------");

                for (int i = 0; i < NumberOfSides; i++)
                {
                    Console.WriteLine($"{namesOfSides[i]}: {lengthsOfSides[i]}");
                }

                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"Area: {Area}");
                Console.WriteLine("---------------------------------------------");
            }
        }

        public override double CalculateArea()
        {
            if (lengthsOfSides == null || vertices == null)
            {
                Console.WriteLine("Operation isn't available!");
                return 0;
            }

            Area = lengthsOfSides[0] * lengthsOfSides[1];
            return Area;
        }

        public override void CalculateSides()
        {
            if (vertices == null)
            {
                Console.WriteLine("Vertices are not set!");
            }
            else
            {
                lengthsOfSides = new double[NumberOfSides];

                lengthsOfSides[0] = CalculateLength(vertices[0, 0], vertices[0, 1], vertices[1, 0], vertices[1, 1]);
                lengthsOfSides[1] = CalculateLength(vertices[1, 0], vertices[1, 1], vertices[2, 0], vertices[2, 1]);
                lengthsOfSides[2] = CalculateLength(vertices[2, 0], vertices[2, 1], vertices[3, 0], vertices[3, 1]);
                lengthsOfSides[3] = CalculateLength(vertices[3, 0], vertices[3, 1], vertices[0, 0], vertices[0, 1]);
            }
        }

        private double CalculateLength(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt(Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2));
        }
    }
}
