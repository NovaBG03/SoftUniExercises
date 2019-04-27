﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace buuniesProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int playerRow = -1;
            int playerCol = -1;

            Queue<int> rabbitsRow = new Queue<int>();
            Queue<int> rabbitsCol = new Queue<int>();

            string output = null;

            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            char[][] lair = new char[rows][];

            for (int row = 0; row < lair.Length; row++)
            {
                lair[row] = new char[cols];
                char[] line = Console.ReadLine().ToCharArray();

                for (int col = 0; col < lair[row].Length; col++)
                {
                    lair[row][col] = line[col];

                    if (line[col] == 'B')
                    {
                        rabbitsRow.Enqueue(row);
                        rabbitsCol.Enqueue(col);
                    }
                    else if (line[col] == 'P')
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }

            //B - bunnies
            //P - player
            //. - free space

            char[] commands = Console.ReadLine().ToCharArray(); //L R U D

            foreach (char command in commands)
            {
                bool isEnd = false;

                lair[playerRow][playerCol] = '.';

                switch (command)
                {
                    case 'U':
                        playerRow--;
                        break;
                    case 'D':
                        playerRow++;
                        break;
                    case 'L':
                        playerCol--;
                        break;
                    case 'R':
                        playerCol++;
                        break;
                    default:
                        break;
                }

                if (!IsInMatrixRange(lair, playerRow, playerCol))
                {
                    isEnd = true;

                    switch (command)
                    {
                        case 'U':
                            playerRow++;
                            break;
                        case 'D':
                            playerRow--;
                            break;
                        case 'L':
                            playerCol++;
                            break;
                        case 'R':
                            playerCol--;
                            break;
                        default:
                            break;
                    }

                    output = string.Format("won: {0} {1}", playerRow, playerCol);
                }
                else if (lair[playerRow][playerCol] == '.')
                {
                    lair[playerRow][playerCol] = 'P';
                }

                int startedRabbitsCount = rabbitsRow.Count;
                for (int i = 0; i < startedRabbitsCount; i++)
                {
                    int currentRabbitRow = rabbitsRow.Dequeue();
                    int currentRabbitCol = rabbitsCol.Dequeue();

                    int currentChildRow = currentRabbitRow - 1;
                    int currentChildCol = currentRabbitCol;

                    if (IsInMatrixRange(lair, currentChildRow, currentChildCol))
                    {
                        rabbitsRow.Enqueue(currentChildRow);
                        rabbitsCol.Enqueue(currentChildCol);
                        lair[currentChildRow][currentChildCol] = 'B';
                    }

                    currentChildRow = currentRabbitRow + 1;
                    currentChildCol = currentRabbitCol;

                    if (IsInMatrixRange(lair, currentChildRow, currentChildCol))
                    {
                        rabbitsRow.Enqueue(currentChildRow);
                        rabbitsCol.Enqueue(currentChildCol);
                        lair[currentChildRow][currentChildCol] = 'B';
                    }

                    currentChildRow = currentRabbitRow;
                    currentChildCol = currentRabbitCol + 1;

                    if (IsInMatrixRange(lair, currentChildRow, currentChildCol))
                    {
                        rabbitsRow.Enqueue(currentChildRow);
                        rabbitsCol.Enqueue(currentChildCol);
                        lair[currentChildRow][currentChildCol] = 'B';
                    }

                    currentChildRow = currentRabbitRow;
                    currentChildCol = currentRabbitCol - 1;

                    if (IsInMatrixRange(lair, currentChildRow, currentChildCol))
                    {
                        rabbitsRow.Enqueue(currentChildRow);
                        rabbitsCol.Enqueue(currentChildCol);
                        lair[currentChildRow][currentChildCol] = 'B';
                    }

                }

                //Print(lair);

                if (lair[playerRow][playerCol] == 'B')
                {
                    if (!isEnd)
                    {
                        output = string.Format("dead: {0} {1}", playerRow, playerCol);
                        isEnd = true;
                        break;
                    }
                }

                if (isEnd)
                {
                    break;
                }
            }

            Print(lair);
            Console.WriteLine(output);
        }

        private static void Print(char[][] lair)
        {
            for (int col = 0; col < lair.Length; col++)
            {
                Console.WriteLine(string.Join("", lair[col]));
            }
            //Console.WriteLine();
        }

        private static bool IsInMatrixRange(char[][] lair, int row, int col)
        {
            return row >= 0 
                && row < lair.Length 
                && col >= 0 
                && col < lair[0].Length;
        }
    }
}
