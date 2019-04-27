using System;
using System.Collections.Generic;
using System.Linq;

namespace TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[][] stairs = new char[rows][];

            string snakeString = Console.ReadLine();
            Queue<char> snake = new Queue<char>(snakeString);

            FillMatrix(stairs, cols, snake);
            

            int[] shotInput = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int shotRow = shotInput[0];
            int shotCol = shotInput[1];
            int shotRadius = shotInput[2];

            ShootMatrix(stairs, shotRow, shotCol, shotRadius);

            RerangeMatrix(stairs);

            PrintMatrix(stairs);
        }

        private static void RerangeMatrix(char[][] matrix)
        {
            for (int col = 0; col < matrix[0].Length; col++)
            {
                for (int row = matrix.Length - 1; row > 0; row--)
                {
                    if (matrix[row][col] == ' ' && matrix[row - 1][col] != ' ')
                    {
                        int currentRow = row;

                        while (matrix[currentRow][col] == ' ')
                        {
                            matrix[currentRow][col] = matrix[currentRow - 1][col];
                            matrix[currentRow - 1][col] = ' ';
                            currentRow++;
                            if (currentRow >= matrix.Length)
                            {
                                break;
                            }
                        }
                    }
                }
            }
        }

        private static void ShootMatrix(char[][] matrix, int shotRow, int shotCol, int shotRadius)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    bool isShooted = Math.Pow(row - shotRow, 2) + Math.Pow(col - shotCol, 2) <= Math.Pow(shotRadius, 2);

                    if (isShooted)
                    {
                        matrix[row][col] = ' ';
                    }
                }
            }
        }

        private static void FillMatrix(char[][] matrix, int cols, Queue<char> snake)
        {

            for (int row = matrix.Length - 1; row >= 0; row--)
            {
                matrix[row] = new char[cols];

                if ((matrix.Length - row) % 2 == 0)
                {
                    for (int col = 0; col < matrix[row].Length; col++)
                    {
                        matrix[row][col] = snake.Dequeue();
                        snake.Enqueue(matrix[row][col]);
                    }
                }
                else
                {
                    for (int col = matrix[row].Length - 1; col >= 0; col--)
                    {
                        matrix[row][col] = snake.Dequeue();
                        snake.Enqueue(matrix[row][col]);
                    }
                }
            }
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }
    }
}
