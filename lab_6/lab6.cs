using System;

namespace InterfacesAndAbstractClasses
{
    class Program
    {
        public static void Main(string[] args)
        {
            Quadrangle quad = new Quadrangle();
            int[,] verticesQuad = new int[quad.NumberOfSides, 2];
            string[] nameOfVerticesQuad = { "A", "B", "C", "D" };

            for (int i = 0; i < quad.NumberOfSides; i++)
            {
                Console.Write($"Vertex {nameOfVerticesQuad[i]}: x = ");
                verticesQuad[i, 0] = int.Parse(Console.ReadLine());
                Console.Write($"Vertex {nameOfVerticesQuad[i]}: y = ");
                verticesQuad[i, 1] = int.Parse(Console.ReadLine());
            }

            quad.SetVertices(verticesQuad);
            quad.CalculateSides();
            quad.CalculateArea();
            quad.ShowData();

            Triangle trian = new Triangle();
            int[,] verticesTriangle = new int[trian.NumberOfSides, 2];
            string[] nameOfVerticesTriangle = { "A", "B", "C" };

            for (int i = 0; i < trian.NumberOfSides; i++)
            {
                Console.Write($"Vertex {nameOfVerticesTriangle[i]}: x = ");
                verticesTriangle[i, 0] = int.Parse(Console.ReadLine());
                Console.Write($"Vertex {nameOfVerticesTriangle[i]}: y = ");
                verticesTriangle[i, 1] = int.Parse(Console.ReadLine());
            }

            trian.SetVertices(verticesTriangle);
            trian.CalculateSides();
            trian.CalculateArea();
            trian.ShowData();
        }
    }
}

using System;

namespace InterfacesAndAbstractClasses
{
    abstract class Figure
    {
        public double Area { get; set; }
        public abstract int NumberOfSides { get; }
        public abstract double CalculateArea();
        public abstract void CalculateSides();
        
        /// <summary>
        /// Установлює координати вершин фігури.
        /// </summary>
        /// <param name="vertices">Масив координат вершин</param>
        public abstract void SetVertices(int[,] vertices);
        public abstract void ShowData();
    }
}

using System;

namespace InterfacesAndAbstractClasses
{
    class Triangle : Figure
    {
        private double[,] vertices;
        private double[] lengthsOfSides;
        private string[] namesOfSides = { "AB", "BC", "AC" };
        private string[] namesOfVertices = { "A", "B", "C" };
        public override int NumberOfSides { get { return 3; } }

        public override void SetVertices(int[,] vertices)
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
                lengthsOfSides[0] = Math.Sqrt(Math.Pow((vertices[1, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[1, 1] - vertices[0, 1]), 2));
                lengthsOfSides[1] = Math.Sqrt(Math.Pow((vertices[2, 0] - vertices[1, 0]), 2) + Math.Pow((vertices[2, 1] - vertices[1, 1]), 2));
                lengthsOfSides[2] = Math.Sqrt(Math.Pow((vertices[2, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[2, 1] - vertices[0, 1]), 2));
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
    }
}

using System;

namespace InterfacesAndAbstractClasses
{
    class Quadrangle : Figure
    {
        private int[,] vertices;
        private double[] lengthsOfSides;
        private string[] namesOfSides = { "AB", "BC", "CD", "AD" };
        private string[] namesOfVertices = { "A", "B", "C", "D" };
        public override int NumberOfSides { get { return 4; } }

        public override void SetVertices(int[,] vertices)
        {
            this.vertices = new int[NumberOfSides, 2];
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

                lengthsOfSides[0] = Math.Sqrt(Math.Pow((vertices[1, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[1, 1] - vertices[0, 1]), 2));
                lengthsOfSides[1] = Math.Sqrt(Math.Pow((vertices[2, 0] - vertices[1, 0]), 2) + Math.Pow((vertices[2, 1] - vertices[1, 1]), 2));
                lengthsOfSides[2] = Math.Sqrt(Math.Pow((vertices[3, 0] - vertices[2, 0]), 2) + Math.Pow((vertices[3, 1] - vertices[2, 1]), 2));
                lengthsOfSides[3] = Math.Sqrt(Math.Pow((vertices[3, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[3, 1] - vertices[0, 1]), 2));
            }
        }
    }
}
