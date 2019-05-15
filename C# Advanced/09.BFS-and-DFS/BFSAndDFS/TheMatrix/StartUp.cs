using System;
using System.Linq;

namespace TheMatrix
{
    public class StartUp
    {
        public static char[][] matrix;
        public static char startChar;
        public static char fillChar;

        public static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(" ")
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            FillMatrix(rows, cols);

            fillChar = Console.ReadLine().ToCharArray()[0];

            var startCell = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int startRow = startCell[0];
            int startCol = startCell[1];
            startChar = matrix[startRow][startCol];

            FindNextCell(startRow, startCol);

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void FindNextCell(int currentRow, int currentCol)
        {
            if (!IsInside(currentRow, currentCol) || matrix[currentRow][currentCol] != startChar)
            {
                return;
            }

            matrix[currentRow][currentCol] = fillChar;

            FindNextCell(currentRow - 1, currentCol);

            FindNextCell(currentRow + 1, currentCol);

            FindNextCell(currentRow, currentCol - 1);

            FindNextCell(currentRow, currentCol + 1);
        }

        private static bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.Length
                && col >= 0 && col < matrix[row].Length;
        }

        public static void FillMatrix(int rows, int cols)
        {
            matrix = new char[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();
            }
        }

    }
}