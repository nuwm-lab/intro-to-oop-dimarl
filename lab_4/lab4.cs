using System;

namespace Geometry
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] verticesTrian = new double[Triangle.VertexCount, 2];
            double[,] verticesQuad = new double[Quadrangle.VertexCount, 2];
            string[] nameVerticesTrian = { "A", "B", "C" };
            string[] nameVerticesQuad = { "A", "B", "C", "D" };
            Triangle trian = new Triangle();
            Quadrangle quad = new Quadrangle();

            InputVertices(trian, nameVerticesTrian, verticesTrian);
            trian.ShowVertices();
            trian.CalculateSides();
            Console.WriteLine($"Area of the triangle: {trian.CalculateArea()}");

            InputVertices(quad, nameVerticesQuad, verticesQuad);
            quad.ShowVertices();
            quad.CalculateSides();
            Console.WriteLine($"Area of the quadrangle: {quad.CalculateArea()}");
        }

        static void InputVertices(Shape shape, string[] names, double[,] vertices)
        {
            for (int i = 0; i < shape.VertexCount; i++)
            {
                Console.WriteLine($"Enter coordinates for vertex {names[i]}: ");
                vertices[i, 0] = Convert.ToDouble(Console.ReadLine());
                vertices[i, 1] = Convert.ToDouble(Console.ReadLine());
            }

            shape.SetVertices(vertices);
        }
    }

    class Shape
    {
        protected double[,] vertices;
        public int VertexCount { get; protected set; }

        public virtual void SetVertices(double[,] vertices)
        {
            this.vertices = vertices;
        }

        public void ShowVertices()
        {
            if (vertices == null)
            {
                Console.WriteLine("Coordinates not set!");
            }
            else
            {
                Console.WriteLine("-----------------------------");
                for (int i = 0; i < VertexCount; i++)
                {
                    Console.WriteLine($"Vertex {i + 1}: x = {vertices[i, 0]}, y = {vertices[i, 1]}");
                }
                Console.WriteLine("-----------------------------");
            }
        }

        public virtual void CalculateSides()
        {
            // To be implemented in child classes
        }

        public virtual double CalculateArea()
        {
            // To be implemented in child classes
            return 0;
        }
    }

    class Triangle : Shape
    {
        public Triangle()
        {
            VertexCount = 3;
        }

        public override void CalculateSides()
        {
            // Implementation for calculating sides of a triangle
        }

        public override double CalculateArea()
        {
            // Implementation for calculating area of a triangle
            return 0;
        }
    }

    class Quadrangle : Shape
    {
        public Quadrangle()
        {
            VertexCount = 4;
        }

        public override void CalculateSides()
        {
            // Implementation for calculating sides of a quadrangle
        }

        public override double CalculateArea()
        {
            // Implementation for calculating area of a quadrangle
            return 0;
        }
    }
}
