using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows, columns;

            Console.Write("Enter the number matrix rows: ");
            rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter the number matrix columns: ");
            columns = Convert.ToInt32(Console.ReadLine());

            Matrix mtrx = new Matrix(rows, columns);

            mtrx.FillMatrix();
            mtrx.ShowMatrix();
            int diag_sum = mtrx.CaclDiagonalSum();

            Console.WriteLine($"Sum of diagonal elements: {diag_sum}");
        }
    }
}
using System;

namespace Matrix
{
    class Matrix
    {
        private int rows;
        private int columns;
        private int[,] matrix;
        public Matrix(int row, int column)
        {
            this.rows = row;
            this.columns = column;
            matrix = new int[row, column];
        }
        public Matrix()
        {
            this.rows = 0;
            this.columns = 0;
            matrix = null;
        }

        public void FillMatrix()
        {
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rand.Next(-20, 21);
                }
            }

        }
        public int CaclDiagonalSum()
        {
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j) sum += matrix[i, j];
                }
            }
            return sum;
        }
        public void ShowMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j], -10}");
                }
                Console.WriteLine();
            }
        }

    }
}
using System;

namespace Matrix
{
    class Matrix
    {
        private int rows;
        private int columns;
        private int[,] matrix;
        public Matrix(int row, int column)
        {
            this.rows = row;
            this.columns = column;
            matrix = new int[row, column];
        }
        public Matrix()
        {
            this.rows = 0;
            this.columns = 0;
            matrix = null;
        }

        public void FillMatrix()
        {
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rand.Next(-20, 21);
                }
            }

        }
        public int CaclDiagonalSum()
        {
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j) sum += matrix[i, j];
                }
            }
            return sum;
        }
        public void ShowMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j], -10}");
                }
                Console.WriteLine();
            }
        }

    }
}

