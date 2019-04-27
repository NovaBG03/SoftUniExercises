using System;
using System.Linq;

namespace RubiksMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            int[][] rubiksMatrix = new int[rows][];

            int increasingIntiger = 1;
            for (int row = 0; row < rubiksMatrix.Length; row++)
            {
                rubiksMatrix[row] = new int[cols];

                for (int col = 0; col < rubiksMatrix[row].Length; col++)
                {
                    rubiksMatrix[row][col] = increasingIntiger;
                    increasingIntiger++;
                }
            }

            int commandsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandsCount; i++)
            {
                string[] command = Console.ReadLine().Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                int rowCol = int.Parse(command[0]);
                string direction = command[1];
                int moves = int.Parse(command[2]);

                int row = -1;
                int col = -1;

                switch (direction)
                {
                    case "up":
                        moves = moves % rubiksMatrix.Length;
                        for (int j = 0; j < moves; j++)
                        {
                            row = rubiksMatrix.Length - 1;
                            col = rowCol;

                            int value = rubiksMatrix[0][col];

                            for (int k = 0; k < rubiksMatrix.Length; k++)
                            {
                                int swap = rubiksMatrix[row][col];
                                rubiksMatrix[row][col] = value;
                                value = swap;

                                if (row != 0)
                                {
                                    row--;
                                }
                                else
                                {
                                    row = rubiksMatrix.Length - 1;
                                }
                            }
                        }
                        break;
                    case "down":
                        moves = moves % rubiksMatrix.Length;
                        for (int j = 0; j < moves; j++)
                        {
                            row = 0;
                            col = rowCol;

                            int value = rubiksMatrix[rubiksMatrix.Length - 1][col];

                            for (int k = 0; k < rubiksMatrix.Length; k++)
                            {
                                int swap = rubiksMatrix[row][col];
                                rubiksMatrix[row][col] = value;
                                value = swap;

                                if (row != rubiksMatrix.Length - 1)
                                {
                                    row++;
                                }
                                else
                                {
                                    row = 0;
                                }
                            }
                        }
                        break;
                    case "left":
                        moves = moves % rubiksMatrix[rows - 1].Length;
                        for (int j = 0; j < moves; j++)
                        {
                            row = rowCol;
                            col = rubiksMatrix[row].Length - 1;

                            int value = rubiksMatrix[row][0];

                            for (int k = 0; k < rubiksMatrix[row].Length; k++)
                            {
                                int swap = rubiksMatrix[row][col];
                                rubiksMatrix[row][col] = value;
                                value = swap;

                                if (col != 0)
                                {
                                    col--;
                                }
                                else
                                {
                                    col = rubiksMatrix[row].Length - 1;
                                }
                            }
                        }
                        break;
                    case "right":
                        moves = moves % rubiksMatrix[rows - 1].Length;
                        for (int j = 0; j < moves; j++)
                        {
                            row = rowCol;
                            col = 0;

                            int value = rubiksMatrix[row][rubiksMatrix[row].Length - 1];

                            for (int k = 0; k < rubiksMatrix[row].Length; k++)
                            {
                                int swap = rubiksMatrix[row][col];
                                rubiksMatrix[row][col] = value;
                                value = swap;

                                if (col != rubiksMatrix[row].Length - 1)
                                {
                                    col++;
                                }
                                else
                                {
                                    col = 0;
                                }
                            }
                        }
                        break;
                    default:
                        break;
                }
            }

            increasingIntiger = 1;
            for (int row = 0; row < rubiksMatrix.Length; row++)
            {
                for (int col = 0; col < rubiksMatrix[row].Length; col++)
                {
                    if (rubiksMatrix[row][col] == increasingIntiger)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int findRow = 0; findRow < rubiksMatrix.Length; findRow++)
                        {
                            bool isFounded = false;
                            for (int findCol = 0; findCol < rubiksMatrix[findRow].Length; findCol++)
                            {
                                if (rubiksMatrix[findRow][findCol] == increasingIntiger)
                                {
                                    int swap = rubiksMatrix[row][col];
                                    rubiksMatrix[row][col] = rubiksMatrix[findRow][findCol];
                                    rubiksMatrix[findRow][findCol] = swap;
                                    Console.WriteLine($"Swap ({row}, {col}) with ({findRow}, {findCol})");
                                    isFounded = true;
                                    break;
                                }
                            }

                            if (isFounded)
                            {
                                break;
                            }
                        }
                    }

                    increasingIntiger++;
                }
            }
        }
    }
}