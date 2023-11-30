using System;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows, columns;

            Console.Write("Введіть кількість рядків матриці: ");
            rows = Convert.ToInt32(Console.ReadLine());
            Console.Write("Введіть кількість стовпців матриці: ");
            columns = Convert.ToInt32(Console.ReadLine());

            Matrix mtrx = new Matrix(rows, columns);

            mtrx.FillMatrix();
            mtrx.DisplayMatrix();
            int diag_sum = mtrx.GetDiagonalSum();

            Console.WriteLine($"Сума діагональних елементів: {diag_sum}");
        }
    }
}

using System;

namespace Matrix
{
    class Matrix
    {
        private int Rows { get; }
        private int Columns { get; }
        private int[,] MatrixArray { get; }

        public Matrix(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            MatrixArray = new int[rows, columns];
        }

        private void FillMatrix()
        {
            Random rand = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    MatrixArray[i, j] = rand.Next(-20, 21);
                }
            }
        }

        private int CalculateDiagonalSum()
        {
            int sum = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (i == j) sum += MatrixArray[i, j];
                }
            }
            return sum;
        }

        private void ShowMatrix()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write($"{MatrixArray[i, j], -10}");
                }
                Console.WriteLine();
            }
        }

        public int GetDiagonalSum()
        {
            return CalculateDiagonalSum();
        }

        public void DisplayMatrix()
        {
            ShowMatrix();
        }
    }
}
