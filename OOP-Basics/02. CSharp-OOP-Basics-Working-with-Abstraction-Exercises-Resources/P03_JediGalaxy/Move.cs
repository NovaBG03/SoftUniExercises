using System;
using System.Collections.Generic;
using System.Text;

namespace P03_JediGalaxy
{
    public static class Move
    {
        public static void FillMatrix(int x, int y)
        {
            int value = 0;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }


        public static void Evil(int x, int y)
        {
            while (x >= 0 && y >= 0)
            {
                if (IsInMatrix(x, y))
                {
                    matrix[x, y] = 0;
                }
                x--;
                y--;
            }
        }


        public static long Player(int x, int y)
        {
            long sum = 0;

            while (x >= 0 && y < matrix.GetLength(1))
            {
                if (IsInMatrix(x, y))
                {
                    sum += matrix[x, y];
                }

                y++;
                x--;
            }

            return sum;
        }

        private static bool IsInMatrix(int x, int y)
        {
            return x >= 0 && x < matrix.GetLength(0) && y >= 0 && y < matrix.GetLength(1);
        }

    }
}
