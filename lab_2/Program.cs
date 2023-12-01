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

            Matrix matrix = new Matrix(rows, columns);

            matrix.FillMatrix();
            matrix.DisplayMatrix();
            int diagonalSum = matrix.GetDiagonalSum();

            Console.WriteLine($"Сума діагональних елементів: {diagonalSum}");
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
        private int[,] matrixArray;

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matrixArray = new int[rows, columns];
        }

        private void FillMatrix()
        {
            Random rand = new Random();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrixArray[i, j] = rand.Next(-20, 21);
                }
            }
        }

        private int CalculateDiagonalSum()
        {
            int sum = 0;
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j) sum += matrixArray[i, j];
                }
            }
            return sum;
        }

        private void ShowMatrix()
        {
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrixArray[i, j], -10}");
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

        public int Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        public int Columns
        {
            get { return columns; }
            set { columns = value; }
        }
    }
}
