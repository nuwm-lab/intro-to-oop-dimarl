User
using System;

namespace inheritance
{
    class Program
    {
        static void Main(string[] args)
        {
            int userChoise;
            bool check = true;

            Triangle baseobj;

            while (check)
            {
                Console.WriteLine("Enter '1' if you want to work with triangle, enter '0' - with quadrangle:  ");
                userChoise = int.Parse(Console.ReadLine());

                if (userChoise == 1)
                {
                    baseobj = new Triangle();

                    double[,] verticesTrian = new double[Triangle.CountOfVerticesTrian, 2];
                    string[] name_verticesTrian = { "A", "B", "C" };

                    for (int i = 0; i < Triangle.CountOfVerticesTrian; i++)
                    {
                        Console.WriteLine($"Enter coordinate for {name_verticesTrian[i]} vertex: ");
                        verticesTrian[i, 0] = Convert.ToDouble(Console.ReadLine());
                        verticesTrian[i, 1] = Convert.ToDouble(Console.ReadLine());
                    }

                    baseobj.SetVertices(verticesTrian);
                    baseobj.ShowVertices();
                    baseobj.CaclOfSides();

                    Console.WriteLine($"Area of the triangle: {baseobj.AreaCalc()}");

                    check = false;
                }
                else if (userChoise == 0)
                {
                    baseobj = new Quadrangle();

                    double[,] verticesQuad = new double[Quadrangle.CountOfVerticesQuad, 2];
                    string[] name_verticesQuad = { "A", "B", "C", "D" };

                    for (int i = 0; i < Quadrangle.CountOfVerticesQuad; i++)
                    {
                        Console.WriteLine($"Enter coordinate for {name_verticesQuad[i]} vertex: ");
                        verticesQuad[i, 0] = Convert.ToDouble(Console.ReadLine());
                        verticesQuad[i, 1] = Convert.ToDouble(Console.ReadLine());
                    }

                    baseobj.SetVertices(verticesQuad);
                    baseobj.ShowVertices();
                    baseobj.CaclOfSides();

                    Console.WriteLine($"Area of the quadrangle: {baseobj.AreaCalc()}");

                    check = false;
                }
                else
                {
                    Console.WriteLine("Enter '1' or '0'!");
                }
            }
        }
    }
}

using System;

namespace inheritance
{
    class Triangle
    {
        private const int CountOfVert = 3;
        public static int CountOfVerticesTrian
        {
            get { return CountOfVert; }
        }

        private double[,] vertices;
        private double[] length_of_sides;
        private string[] name_of_sides = { "AB", "BC", "AC" };

        public virtual void SetVertices(double[,] vertices)
        {
            this.vertices = new double[CountOfVert, 2];
            for (int i = 0; i < CountOfVert; i++)
            {
                this.vertices[i, 0] = vertices[i, 0];
                this.vertices[i, 1] = vertices[i, 1];
            }
        }

        public virtual void ShowVertices()
        {
            if (vertices == null)
            {
                Console.WriteLine("The coordinates don't set!");
            }
            else
            {
                Console.WriteLine("-----------------------------");
                for (int i = 0; i < CountOfVert; i++)
                {
                    Console.WriteLine($"Vertex {i + 1}: x = {vertices[i, 0]}, y = {vertices[i, 1]}");
                }
                Console.WriteLine("-----------------------------");
            }
        }
        public virtual void CaclOfSides()
        {
            Console.WriteLine("-----------------------------");
            if (vertices == null)
            {
                Console.WriteLine("The coordinates don't set!");
                Console.WriteLine("-----------------------------");
            }
            else
            {
                length_of_sides = new double[CountOfVerticesTrian];
                this.length_of_sides[0] = Math.Sqrt(Math.Pow((vertices[1, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[1, 1] - vertices[0, 1]), 2));
                this.length_of_sides[1] = Math.Sqrt(Math.Pow((vertices[2, 0] - vertices[1, 0]), 2) + Math.Pow((vertices[2, 1] - vertices[1, 1]), 2));
                this.length_of_sides[2] = Math.Sqrt(Math.Pow((vertices[2, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[2, 1] - vertices[0, 1]), 2));

                for (int i = 0; i < length_of_sides.Length; i++)
                {
                    Console.WriteLine($"Length of {this.name_of_sides[i]}: {this.length_of_sides[i]}");
                }
                Console.WriteLine("-----------------------------");
            }
        }

        public virtual double AreaCalc()
        {
            if (vertices == null || length_of_sides == null)
            {
                Console.WriteLine("The coordinates don't set or side lengths don't calculate");
                return 0;
            }
            else
            {
                double area, perimeter = 0;
                for (int i = 0; i < CountOfVerticesTrian; i++)
                {
                    perimeter += length_of_sides[i];
                }
                area = Math.Sqrt((perimeter / 2) * (perimeter / 2 - length_of_sides[0]) * (perimeter / 2 - length_of_sides[1]) * (perimeter / 2 - length_of_sides[2]));
                return area;
            }
        }
    }
}



using System;

namespace inheritance
{
    class Quadrangle : Triangle
    {
        private const int CountOfVert = 4;
        public static int CountOfVerticesQuad
        {
            get { return CountOfVert; }
        }

        private double[,] vertices;
        private double[] length_of_sides;
        private string[] name_of_sides = { "AB", "BC", "CD", "AD" };

        public override void SetVertices(double[,] vertices)
        {
            this.vertices = new double[CountOfVert, 2];
            for (int i = 0; i < CountOfVert; i++)
            {
                this.vertices[i, 0] = vertices[i, 0];
                this.vertices[i, 1] = vertices[i, 1];
            }
        }

        public override void ShowVertices()
        {
            if (vertices == null)
            {
                Console.WriteLine("The coordinates don't set!");
            }
            else
            {
                Console.WriteLine("-----------------------------");
                for (int i = 0; i < CountOfVert; i++)
                {
                    Console.WriteLine($"Vertex {i + 1}: x = {vertices[i, 0]}, y = {vertices[i, 1]}");
                }
                Console.WriteLine("-----------------------------");
            }
        }

        public override void CaclOfSides()
        {
            Console.WriteLine("-----------------------------");
            if (vertices == null)
            {
                Console.WriteLine("The coordinates don't set!");
                Console.WriteLine("-----------------------------");
            }
            else
            {
                length_of_sides = new double[CountOfVerticesQuad];
                this.length_of_sides[0] = Math.Sqrt(Math.Pow((vertices[1, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[1, 1] - vertices[0, 1]), 2));
                this.length_of_sides[1] = Math.Sqrt(Math.Pow((vertices[2, 0] - vertices[1, 0]), 2) + Math.Pow((vertices[2, 1] - vertices[1, 1]), 2));
                this.length_of_sides[2] = Math.Sqrt(Math.Pow((vertices[3, 0] - vertices[2, 0]), 2) + Math.Pow((vertices[3, 1] - vertices[2, 1]), 2));
                this.length_of_sides[3] = Math.Sqrt(Math.Pow((vertices[3, 0] - vertices[0, 0]), 2) + Math.Pow((vertices[3, 1] - vertices[0, 1]), 2));

                for (int i = 0; i < length_of_sides.Length; i++)
                {
                    Console.WriteLine($"Length of {this.name_of_sides[i]}: {this.length_of_sides[i]}");
                }
                Console.WriteLine("-----------------------------");
            }
        }
        public override double AreaCalc()
        {
            if (vertices == null || length_of_sides == null)
            {
                Console.WriteLine("The coordinates don't set or side lengths don't calculate");
                return 0;
            }
            else
            {
                double area = 0;

                area = length_of_sides[0] * length_of_sides[1];
                return area;
            }
        }
    }
}
