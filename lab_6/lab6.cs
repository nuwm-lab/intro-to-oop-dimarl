User
using System;

namespace InterfaceAndAbsractClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Quadrangle quad = new Quadrangle();
            int[,] verticesQuad = new int[quad.NumberOfSides, 2];
            string[] NameOfVerticesQuad = { "A", "B", "C", "D" };

            for (int i = 0; i < quad.NumberOfSides; i++)
            {
                Console.Write($"Vertex {NameOfVerticesQuad[i]}: x = ");
                verticesQuad[i, 0] = int.Parse(Console.ReadLine());
                Console.Write($"Vertex {NameOfVerticesQuad[i]}: y = ");
                verticesQuad[i, 1] = int.Parse(Console.ReadLine());
            }


            quad.SetVertices(verticesQuad);
            quad.CalculateSides();
            quad.CalculateArea();
            quad.ShowData();

            Triangle trian = new Triangle();
            int[,] verticesTriangle = new int[quad.NumberOfSides, 2];
            string[] NameOfVerticesTriangle = { "A", "B", "C"};

            for (int i = 0; i < trian.NumberOfSides; i++)
            {
                Console.Write($"Vertex {NameOfVerticesTriangle[i]}: x = ");
                verticesTriangle[i, 0] = int.Parse(Console.ReadLine());
                Console.Write($"Vertex {NameOfVerticesTriangle[i]}: y = ");
                verticesTriangle[i, 1] = int.Parse(Console.ReadLine());
            }


            trian.SetVertices(verticesQuad);
            trian.CalculateSides();
            trian.CalculateArea();
            trian.ShowData();
        }
    }
}


using System;

namespace InterfaceAndAbsractClass
{
    abstract class Figure
    { 
        public double Area { get; set; }
        public abstract int NumberOfSides { get;}
        public abstract double CalculateArea();
        public abstract void CalculateSides();
        public abstract void SetVertices(int[,] vertices);
        public abstract void ShowData();
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAndAbsractClass
{
    class Triangle : Figure
    {
        private double[,] vertices;
        private double[] LenghtsOfSides;
        private string[] NamesOfSides = { "AB", "BC", "AC" };
        private string[] NamesOfVertices = { "A", "B", "A" };
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
            if (vertices == null || LenghtsOfSides == null)
            {
                Console.WriteLine("Operation isn't available!");
                return 0;
            }
            else
            {
                double perimeter = 0;
                for (int i = 0; i < NumberOfSides; i++)
                {
                    perimeter += LenghtsOfSides[i];
                }
                Area = Math.Sqrt((perimeter / 2) * (perimeter / 2 - LenghtsOfSides[0]) * (perimeter / 2 - LenghtsOfSides[1]) * (perimeter / 2 - LenghtsOfSides[2]));
                return Area;
            }
        }

        public override void CalculateSides()
        {
            if (vertices == null)
            {
                Console.WriteLine("The coordinates don't set!");
            }
            else
            {
                LenghtsOfSides = new double[NumberOfSides];
                this.LenghtsOfSides[0] = Math.Sqrt(Math.Pow((vertices[1, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[1, 1] - vertices[0, 1]), 2));
                this.LenghtsOfSides[1] = Math.Sqrt(Math.Pow((vertices[2, 0] - vertices[1, 0]), 2) + Math.Pow((vertices[2, 1] - vertices[1, 1]), 2));
                this.LenghtsOfSides[2] = Math.Sqrt(Math.Pow((vertices[2, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[2, 1] - vertices[0, 1]), 2));
            }
        }


        public override void ShowData()
        {
            if (LenghtsOfSides == null || vertices == null)
            {
                Console.WriteLine("Operation isn't available!");
            }
            else
            {
                Console.WriteLine("---------------------------------------------");

                for (int i = 0; i < NumberOfSides; i++)
                {
                    Console.WriteLine($"{NamesOfVertices[i]}: x = {vertices[i, 0]}, y = {vertices[i, 1]}");
                }

                Console.WriteLine("---------------------------------------------");

                for (int i = 0; i < NumberOfSides; i++)
                {
                    Console.WriteLine($"{NamesOfSides[i]}: {LenghtsOfSides[i]}");
                }

                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"Area: {Area}");
                Console.WriteLine("---------------------------------------------");
            }
        }
    }
}


using System;

namespace InterfaceAndAbsractClass
{
    class Quadrangle : Figure
    {
        private int[,] vertices;
        private double[] LenghtOfSides;
        private string[] NamesOfSides = { "AB", "BC", "CD", "AD" };
        private string[] NamesOfVertices = { "A", "B", "C", "D" };
        public override int NumberOfSides { get { return 4; }}

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
            if (LenghtOfSides == null || vertices == null)
            {
                Console.WriteLine("Operation isn't available!");
            }
            else
            {
                Console.WriteLine("---------------------------------------------");

                for (int i = 0; i < NumberOfSides; i++)
                {
                    Console.WriteLine($"{NamesOfVertices[i]}: x = {vertices[i, 0]}, y = {vertices[i, 1]}");
                }

                Console.WriteLine("---------------------------------------------");

                for (int i = 0; i < NumberOfSides; i++)
                {
                    Console.WriteLine($"{NamesOfSides[i]}: {LenghtOfSides[i]}");
                }

                Console.WriteLine("---------------------------------------------");
                Console.WriteLine($"Area: {Area}");
                Console.WriteLine("---------------------------------------------");
            }
        }

        public override double CalculateArea()
        {
            if (LenghtOfSides == null || vertices == null)
            {
                Console.WriteLine("Operation isn't available!");
            }

            Area = LenghtOfSides[0] * LenghtOfSides[1];
            return Area;
        }

        public override void CalculateSides()
        {
            if(vertices == null)
            {
                Console.WriteLine("Vertices don't set!");
            }
            else
            {
                LenghtOfSides = new double[NumberOfSides];

                LenghtOfSides[0] = Math.Sqrt(Math.Pow((vertices[1, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[1, 1] - vertices[0, 1]), 2));
                LenghtOfSides[1] = Math.Sqrt(Math.Pow((vertices[2, 0] - vertices[1, 0]), 2) + Math.Pow((vertices[2, 1] - vertices[1, 1]), 2));
                LenghtOfSides[2] = Math.Sqrt(Math.Pow((vertices[3, 0] - vertices[2, 0]), 2) + Math.Pow((vertices[3, 1] - vertices[2, 1]), 2));
                LenghtOfSides[3] = Math.Sqrt(Math.Pow((vertices[3, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[3, 1] - vertices[0, 1]), 2));
         
            }
        }
    }
}
