using System;
using System.Linq;

namespace DiagonalDiff
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int matrixSize = int.Parse(Console.ReadLine());

            int[][] matrix = new int[matrixSize][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            }

            int primaryDiagonal = CalculateDiagonal(matrix, "primary");
            int secondaryDiagonal = CalculateDiagonal(matrix, "secondary");

            Console.WriteLine(Math.Abs(primaryDiagonal - secondaryDiagonal));
        }

        private static int CalculateDiagonal(int[][] matrix, string diagonalType)
        {
            int row = -1;
            int col = -1;

            if (diagonalType == "primary")
            {
                row = 0;
                col = 0;
            }
            else if (diagonalType == "secondary")
            {
                row = 0;
                col = matrix[row].Length - 1;
            }

            int diagonal = 0;

            while (true)
            {
                if (IsOutTheMatrix(matrix, row, col))
                {
                    break;
                }

                diagonal += matrix[row][col];

                if (diagonalType == "primary")
                {
                    row++;
                    col++;
                }
                else if (diagonalType == "secondary")
                {
                    row++;
                    col--;
                }
            }

            return diagonal;
        }

        private static bool IsOutTheMatrix(int[][] matrix, int row, int col)
        {
            return row < 0
                   || row > matrix.Length - 1
                   || col < 0
                   || col > matrix[row].Length - 1;
        }
    }
}
