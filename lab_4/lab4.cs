using System;

namespace Inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] verticesTrian = new double[Triangle.CountOfVerticesTrian, 2];
            double[,] verticesQuad = new double[Quadrangle.CountOfVerticesQuad, 2];
            string[] nameVerticesTrian = { "A", "B", "C" };
            string[] nameVerticesQuad = { "A", "B", "C", "D" };
            Triangle trian = new Triangle();
            Quadrangle quad = new Quadrangle();

            for (int i = 0; i < Triangle.CountOfVerticesTrian; i++)
            {
                Console.WriteLine($"Введіть координати для вершини {nameVerticesTrian[i]}: ");
                verticesTrian[i, 0] = Convert.ToDouble(Console.ReadLine());
                verticesTrian[i, 1] = Convert.ToDouble(Console.ReadLine());
            }

            trian.SetVertices(verticesTrian);
            trian.ShowVertices();
            trian.CalculateSides();
            Console.WriteLine($"Площа трикутника: {trian.CalculateArea()}");

            for (int i = 0; i < Quadrangle.CountOfVerticesQuad; i++)
            {
                Console.WriteLine($"Введіть координати для вершини {nameVerticesQuad[i]}: ");
                verticesQuad[i, 0] = Convert.ToDouble(Console.ReadLine());
                verticesQuad[i, 1] = Convert.ToDouble(Console.ReadLine());
            }

            quad.SetVertices(verticesQuad);
            quad.ShowVertices();
            quad.CalculateSides();
            Console.WriteLine($"Площа чотирикутника: {quad.CalculateArea()}");
        }
    }
}

using System;

namespace Inheritance
{
    class Triangle
    {
        private static int CountOfVert = 3;
        public static int CountOfVerticesTrian
        {
            get { return CountOfVert; }
        }

        private double[,] vertices;
        private double[] lengthOfSides;
        private string[] nameOfSides = { "AB", "BC", "AC" };

        public void SetVertices(double[,] vertices)
        {
            this.vertices = new double[CountOfVert, 2];
            for (int i = 0; i < CountOfVert; i++)
            {
                this.vertices[i, 0] = vertices[i, 0];
                this.vertices[i, 1] = vertices[i, 1];
            }
        }

        public void ShowVertices()
        {
            if (vertices == null)
            {
                Console.WriteLine("Координати не встановлені!");
            }
            else
            {
                Console.WriteLine("-----------------------------");
                for (int i = 0; i < CountOfVert; i++)
                {
                    Console.WriteLine($"Вершина {i + 1}: x = {vertices[i, 0]}, y = {vertices[i, 1]}");
                }
                Console.WriteLine("-----------------------------");
            }
        }

        public void CalculateSides()
        {
            Console.WriteLine("-----------------------------");
            if (vertices == null)
            {
                Console.WriteLine("Координати не встановлені!");
                Console.WriteLine("-----------------------------");
            }
            else
            {
                lengthOfSides = new double[CountOfVerticesTrian];
                this.lengthOfSides[0] = Math.Sqrt(Math.Pow((vertices[1, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[1, 1] - vertices[0, 1]), 2));
                this.lengthOfSides[1] = Math.Sqrt(Math.Pow((vertices[2, 0] - vertices[1, 0]), 2) + Math.Pow((vertices[2, 1] - vertices[1, 1]), 2));
                this.lengthOfSides[2] = Math.Sqrt(Math.Pow((vertices[2, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[2, 1] - vertices[0, 1]), 2));

                for (int i = 0; i < lengthOfSides.Length; i++)
                {
                    Console.WriteLine($"Довжина {this.nameOfSides[i]}: {this.lengthOfSides[i]}");
                }
                Console.WriteLine("-----------------------------");
            }
        }

        public double CalculateArea()
        {
            if (vertices == null || lengthOfSides == null)
            {
                Console.WriteLine("Координати не встановлені або довжини сторін не обчислені");
                return 0;
            }
            else
            {
                double area, perimeter = 0;
                for (int i = 0; i < CountOfVerticesTrian; i++)
                {
                    perimeter += lengthOfSides[i];
                }
                area = Math.Sqrt((perimeter / 2) * (perimeter / 2 - lengthOfSides[0]) * (perimeter / 2 - lengthOfSides[1]) * (perimeter / 2 - lengthOfSides[2]));
                return area;
            }
        }
    }
}

using System;

namespace Inheritance
{
    class Quadrangle : Triangle
    {
        private static int CountOfVert = 4;
        public static int CountOfVerticesQuad
        {
            get { return CountOfVert; }
        }

        private double[,] vertices;
        private double[] lengthOfSides;
        private string[] nameOfSides = { "AB", "BC", "CD", "AD" };

        public new void SetVertices(double[,] vertices)
        {
            this.vertices = new double[CountOfVert, 2];
            for (int i = 0; i < CountOfVert; i++)
            {
                this.vertices[i, 0] = vertices[i, 0];
                this.vertices[i, 1] = vertices[i, 1];
            }
        }

        public new void ShowVertices()
        {
            if (vertices == null)
            {
                Console.WriteLine("Координати не встановлені!");
            }
            else
            {
                Console.WriteLine("-----------------------------");
                for (int i = 0; i < CountOfVert; i++)
                {
                    Console.WriteLine($"Вершина {i + 1}: x = {vertices[i, 0]}, y = {vertices[i, 1]}");
                }
                Console.WriteLine("-----------------------------");
            }
        }

        public new void CalculateSides()
        {
            Console.WriteLine("-----------------------------");
            if (vertices == null)
            {
                Console.WriteLine("Координати не встановлені!");
                Console.WriteLine("-----------------------------");
            }
            else
            {
                lengthOfSides = new double[CountOfVerticesQuad];
                this.lengthOfSides[0] = Math.Sqrt(Math.Pow((vertices[1, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[1, 1] - vertices[0, 1]), 2));
                this.lengthOfSides[1] = Math.Sqrt(Math.Pow((vertices[2, 0] - vertices[1, 0]), 2) + Math.Pow((vertices[2, 1] - vertices[1, 1]), 2));
                this.lengthOfSides[2] = Math.Sqrt(Math.Pow((vertices[3, 0] - vertices[2, 0]), 2) + Math.Pow((vertices[3, 1] - vertices[2, 1]), 2));
                this.lengthOfSides[3] = Math.Sqrt(Math.Pow((vertices[3, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[3, 1] - vertices[0, 1]), 2));

                for (int i = 0; i < lengthOfSides.Length; i++)
                {
                    Console.WriteLine($"Довжина {this.nameOfSides[i]}: {this.lengthOfSides[i]}");
                }
                Console.WriteLine("-----------------------------");
            }
        }

        public new double CalculateArea()
        {
            if (vertices == null || lengthOfSides == null)
            {
                Console.WriteLine("Координати не встановлені або довжини сторін не обчислені");
                return 0;
            }
            else
            {
                double area = 0;
                area = lengthOfSides[0] * lengthOfSides[1];
                return area;
            }
        }
    }
}
