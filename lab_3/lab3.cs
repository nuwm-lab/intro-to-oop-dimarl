using System;

namespace ArrayMatrix
{
    /// <summary>
    /// Represents a matrix and provides operations on it.
    /// </summary>
    class Matrix
    {
        private static Random rand = new Random();
        private int numberOfRows;
        private int numberOfColumns;
        private int[,] matrixArray;

        /// <summary>
        /// Initializes a new instance of the Matrix class with the specified number of rows and columns.
        /// </summary>
        /// <param name="rows">The number of rows in the matrix.</param>
        /// <param name="columns">The number of columns in the matrix.</param>
        public Matrix(int rows, int columns)
        {
            numberOfRows = rows;
            numberOfColumns = columns;
            matrixArray = new int[rows, columns];
        }

        /// <summary>
        /// Fills the matrix with random values.
        /// </summary>
        public void FillMatrix()
        {
            if (matrixArray == null)
            {
                matrixArray = new int[numberOfRows, numberOfColumns];
            }

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    matrixArray[i, j] = rand.Next(-20, 21);
                }
            }
        }

        /// <summary>
        /// Calculates the sum of the elements on the main diagonal of the matrix.
        /// </summary>
        /// <returns>The sum of the main diagonal elements.</returns>
        public int CalculateDiagonalSum()
        {
            int sum = 0;

            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    if (i == j)
                    {
                        sum += matrixArray[i, j];
                    }
                }
            }
            return sum;
        }

        /// <summary>
        /// Displays the matrix elements.
        /// </summary>
        public void ShowMatrix()
        {
            Console.WriteLine("-------------------------------------");
            for (int i = 0; i < numberOfRows; i++)
            {
                for (int j = 0; j < numberOfColumns; j++)
                {
                    Console.Write($"{matrixArray[i, j],-10}");
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
    /// <summary>
    /// Represents operations on matrices.
    /// </summary>
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
