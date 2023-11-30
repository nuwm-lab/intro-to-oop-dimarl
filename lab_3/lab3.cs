using System;

namespace ArrayMatrix
{
    class Matrix
    {
        private static Random rand = new Random();
        private int rows;
        private int columns;
        private int[,] matrix;

        public Matrix(int rows, int columns)
        {
            this.rows = rows;
            this.columns = columns;
            matrix = new int[rows, columns];
        }

        ~Matrix()
        {
            Console.WriteLine("Memory cleaning...");
        }

        public void FillMatrix()
        {
            if (matrix == null)
            {
                matrix = new int[rows, columns];
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = rand.Next(-20, 21);
                }
            }
        }

        public int CalculateDiagonalSum()
        {
            int sum = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i == j)
                    {
                        sum += matrix[i, j];
                    }
                }
            }
            return sum;
        }

        public void ShowMatrix()
        {
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{matrix[i, j],-10}");
                }
                Console.WriteLine();
            }
            Console.WriteLine("-------------------------------------");
        }
    }
}

using System;

namespace ArrayMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of matrices: ");
            int numOfMatrices = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the matrix size: ");
            int matrixSize = Convert.ToInt32(Console.ReadLine());

            Matrix[] arrayOfMatrices = new Matrix[numOfMatrices]; 

            for (int i = 0; i < arrayOfMatrices.Length; i++)
            {
                arrayOfMatrices[i] = new Matrix(matrixSize, matrixSize); 
            }

            foreach (var matrix in arrayOfMatrices)
            {
                matrix.FillMatrix();
                matrix.ShowMatrix();
                Console.WriteLine($"The sum of the elements on the main diagonal: {matrix.CalculateDiagonalSum()}");
            }

            int maxDiagonalSum = arrayOfMatrices[0].CalculateDiagonalSum();
            int index = 0;

            for (int i = 0; i < arrayOfMatrices.Length; i++)
            {
                if (maxDiagonalSum < arrayOfMatrices[i].CalculateDiagonalSum())
                {
                    maxDiagonalSum = arrayOfMatrices[i].CalculateDiagonalSum();
                    index = i;
                }
            }

            Console.WriteLine($"\nThe matrix №{index + 1} has the largest sum of the elements on the main diagonal ({maxDiagonalSum})\n");
        }
    }
}
