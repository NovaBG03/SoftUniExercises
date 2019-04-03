using System;

namespace P06_Sneaking
{
    class Sneaking
    {
        static char[][] board;
        

        static void Main()
        {
            int rows = int.Parse(Console.ReadLine());
            board = new char[rows][];

            for (int row = 0; row < rows; row++)
            {
                char[] input = Console.ReadLine().ToCharArray();
                board[row] = new char[input.Length];
                for (int col = 0; col < input.Length; col++)
                {
                    board[row][col] = input[col];
                }
            }

            char[] moves = Console.ReadLine().ToCharArray();
            int[] playerPosition = new int[2];
            FindCharacter(playerPosition, 'S');
            
            for (int i = 0; i < moves.Length; i++)
            {
                for (int row = 0; row < board.Length; row++)
                {
                    for (int col = 0; col < board[row].Length; col++)
                    {
                        if (board[row][col] == 'b')
                        {
                            MoveB(row, col);
                        }
                        else if (board[row][col] == 'd')
                        {
                            MoveD(row, col);
                        }
                    }
                }

                int[] enemyPosition = new int[2];
                FindCharacter(enemyPosition, 'N');
                
                if (playerPosition[1] < enemyPosition[1] && board[enemyPosition[0]][enemyPosition[1]] == 'd' && enemyPosition[0] == playerPosition[0])
                {
                    board[playerPosition[0]][playerPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {playerPosition[0]}, {playerPosition[1]}");
                    for (int row = 0; row < board.Length; row++)
                    {
                        for (int col = 0; col < board[row].Length; col++)
                        {
                            Console.Write(board[row][col]);
                        }
                        Console.WriteLine();
                    }
                    Environment.Exit(0);
                }
                else if (enemyPosition[1] < playerPosition[1] && board[enemyPosition[0]][enemyPosition[1]] == 'b' && enemyPosition[0] == playerPosition[0])
                {
                    board[playerPosition[0]][playerPosition[1]] = 'X';
                    Console.WriteLine($"Sam died at {playerPosition[0]}, {playerPosition[1]}");
                    for (int row = 0; row < board.Length; row++)
                    {
                        for (int col = 0; col < board[row].Length; col++)
                        {
                            Console.Write(board[row][col]);
                        }
                        Console.WriteLine();
                    }
                    Environment.Exit(0);
                }


                board[playerPosition[0]][playerPosition[1]] = '.';
                switch (moves[i])
                {
                    case 'U':
                        playerPosition[0]--;
                        break;
                    case 'D':
                        playerPosition[0]++;
                        break;
                    case 'L':
                        playerPosition[1]--;
                        break;
                    case 'R':
                        playerPosition[1]++;
                        break;
                    default:
                        break;
                }
                board[playerPosition[0]][playerPosition[1]] = 'S';

                for (int j = 0; j < board[playerPosition[0]].Length; j++)
                {
                    if (board[playerPosition[0]][j] != '.' && board[playerPosition[0]][j] != 'S')
                    {
                        enemyPosition[0] = playerPosition[0];
                        enemyPosition[1] = j;
                    }
                }
                if (board[enemyPosition[0]][enemyPosition[1]] == 'N' && playerPosition[0] == enemyPosition[0])
                {
                    board[enemyPosition[0]][enemyPosition[1]] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    for (int row = 0; row < board.Length; row++)
                    {
                        for (int col = 0; col < board[row].Length; col++)
                        {
                            Console.Write(board[row][col]);
                        }
                        Console.WriteLine();
                    }
                    Environment.Exit(0);
                }
            }
        }

        private static void MoveD(int row, int col)
        {
            if (row >= 0 && row < board.Length && col - 1 >= 0 && col - 1 < board[row].Length)
            {
                board[row][col] = '.';
                board[row][col - 1] = 'd';
            }
            else
            {
                board[row][col] = 'b';
            }
        }

        private static void MoveB(int row, int col)
        {
            if (row >= 0 && row < board.Length && col + 1 >= 0 && col + 1 < board[row].Length)
            {
                board[row][col] = '.';
                board[row][col + 1] = 'b';
                col++;
            }
            else
            {
                board[row][col] = 'd';
            }
        }

        private static void FindCharacter(int[] position ,char player)
        {
            for (int row = 0; row < board.Length; row++)
            {
                for (int col = 0; col < board[row].Length; col++)
                {
                    if (board[row][col] == player)
                    {
                        position[0] = row;
                        position[1] = col;
                    }
                }
            }
        }





    }
}