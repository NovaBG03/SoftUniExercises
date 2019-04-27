using System;
using System.Linq;

namespace Crossfire
{
    class Program
    {
        private static int[][] matrix;

        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            matrix = new int[rows][];

            FillMatrix(cols);

            string input = Console.ReadLine();

            while (input != "Nuke it from orbit")
            {
                int[] command = input.Split()
                    .Select(int.Parse)
                    .ToArray();

                int pointRow = command[0];
                int pointCol = command[1];
                int pointRadius = command[2];

                DestroyCells(pointRow, pointCol, pointRadius);

                RerangeCells();

                input = Console.ReadLine();
            }

            PrintMatrix();
        }

        private static void RerangeCells()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                int counter = 0;

                for (int col = 0; col < matrix[row].Length - 1; col++)
                {
                    bool isZero = matrix[row][col] == 0;

                    if (isZero)
                    {
                        bool isNextZero = matrix[row][col + 1] == 0;

                        if (!isNextZero)
                        {
                            matrix[row][col - counter] = matrix[row][col + 1];
                            matrix[row][col + 1] = 0;
                            counter = 0;
                        }
                        else
                        {
                            counter++;
                        }
                    }
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                bool isRowEmpty = true;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] != 0)
                    {
                        isRowEmpty = false;
                    }
                }

                if (isRowEmpty)
                {
                    MoveMatrixUp(row);
                }
            }
        }

        private static void MoveMatrixUp(int emptyRow)
        {
            for (int row = emptyRow; row < matrix.Length - 1; row++)
            {
                int[] swap = matrix[row];
                matrix[row] = matrix[row + 1];
                matrix[row + 1] = swap;
            }
        }

        private static void DestroyCells(int pointRow, int pointCol, int pointRadius)
        {
            for (int currentRow = pointRow - pointRadius; currentRow < pointRow + pointRadius; currentRow++)
            {
                if (isInMatrix(currentRow, pointCol))
                {
                    matrix[currentRow][pointCol] = 0;
                }
            }

            for (int col = pointCol - pointRadius; col <= pointCol + pointRadius; col++)
            {
                if (isInMatrix(pointRow, col))
                {
                    matrix[pointRow][col] = 0;
                }
            }
        }

        private static bool isInMatrix(int row, int col)
        {
            return row >= 0
                && row < matrix.Length
                && col >= 0
                && col < matrix[0].Length;
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    int currentNumber = matrix[row][col];

                    if (currentNumber != 0)
                    {
                        Console.Write(currentNumber + " ");
                    }
                }

                Console.WriteLine();
            }
        }

        private static void FillMatrix(int cols)
        {
            int increasingIntiger = 1;

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new int[cols];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = increasingIntiger++;
                }
            }
        }
    }
}
