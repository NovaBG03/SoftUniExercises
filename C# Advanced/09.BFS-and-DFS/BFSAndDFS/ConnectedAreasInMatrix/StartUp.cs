using System;
using System.Collections.Generic;
using System.Linq;

namespace ConnectedAreasInMatrix
{
    public class StartUp
    {
        public static char[][] matrix;
        public static List<MatrixInfo> infos;


        public static void Main(string[] args)
        {
            infos = new List<MatrixInfo>();

            int rows = int.Parse(Console.ReadLine());
            int cols = int.Parse(Console.ReadLine());

            FillMatrix(rows, cols);

            GetMatrixInfo();

            infos = infos.OrderByDescending(m => m.Size)
                .ThenBy(a => a.X)
                .ThenBy(b => b.Y)
                .ToList();

            PrintInfo();
        }

        private static void PrintInfo()
        {
            Console.WriteLine($"Total areas found: {infos.Count}");

            int number = 1;
            foreach (var info in infos)
            {
                Console.WriteLine($"Area #{number++} at {info}");
            }
        }

        private static void GetMatrixInfo()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    var currentCell = matrix[row][col];

                    if (currentCell == '-')
                    {
                        MatrixInfo matrixInfo = new MatrixInfo(row, col, 0);

                        FindNextCell(row, col, matrixInfo);

                        infos.Add(matrixInfo);
                    }
                }
            }
        }

        private static void FindNextCell(int currentRow, int currentCol, MatrixInfo matrixInfo)
        {
            if (!IsInside(currentRow, currentCol) || matrix[currentRow][currentCol] != '-')
            {
                return;
            }

            matrix[currentRow][currentCol] = '0';
            matrixInfo.IncrementSize();

            FindNextCell(currentRow - 1, currentCol, matrixInfo);

            FindNextCell(currentRow + 1, currentCol, matrixInfo);

            FindNextCell(currentRow, currentCol - 1, matrixInfo);

            FindNextCell(currentRow, currentCol + 1, matrixInfo);
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
                matrix[row] = Console.ReadLine().ToCharArray();
            }
        }


    }

    public class MatrixInfo
    {
        public MatrixInfo(int x, int y, int size)
        {
            this.X = x;
            this.Y = y;
            this.Size = size;
        }

        public int X { get; private set; }

        public int Y { get; private set; }

        public int Size { get; private set; }

        public void IncrementSize()
        {
            this.Size++;
        }

        public override string ToString()
        {
            return $"({this.X}, {this.Y}), size: {this.Size}";
        }
    }
}
