using System;

namespace TronRacers
{
    public class Player
    {
        public Player(char symbol)
        {
            this.Symbol = symbol;
        }

        public int Row { get; set; }

        public int Col { get; set; }

        public char Symbol { get; private set; }
    }

    public class StartUp
    {
        public static char[][] matrix;
        public static Player playerOne;
        public static Player playerTwo;

        public static void Main(string[] args)
        {
            playerOne = new Player('f');
            playerTwo = new Player('s');

            int rows = int.Parse(Console.ReadLine());
            matrix = new char[rows][];

            CreateBoard();

            while (true)
            {
                var directions = Console.ReadLine().Split();
                string playerOneDirection = directions[0];
                string playerTwoDirection = directions[1];


                MovePlayer(playerOne, playerOneDirection);

                if (matrix[playerOne.Row][playerOne.Col] == playerTwo.Symbol)
                {
                    matrix[playerOne.Row][playerOne.Col] = 'x';
                    break;
                }

                matrix[playerOne.Row][playerOne.Col] = playerOne.Symbol;


                MovePlayer(playerTwo, playerTwoDirection);

                if (matrix[playerTwo.Row][playerTwo.Col] == playerOne.Symbol)
                {
                    matrix[playerTwo.Row][playerTwo.Col] = 'x';
                    break;
                }

                matrix[playerTwo.Row][playerTwo.Col] = playerTwo.Symbol;

            }

            PrintBoard();
        }

        private static void PrintBoard()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join("", matrix[row]));
            }
        }

        private static void MovePlayer(Player player, string direction)
        {
            switch (direction)
            {
                case "up":
                    player.Row--;

                    if (!isInside(player))
                    {
                        player.Row = matrix.Length - 1;
                    }

                    break;
                case "down":
                    player.Row++;

                    if (!isInside(player))
                    {
                        player.Row = 0;
                    }

                    break;
                case "left":
                    player.Col--;

                    if (!isInside(player))
                    {
                        player.Col = matrix[player.Row].Length - 1;
                    }

                    break;
                case "right":
                    player.Col++;

                    if (!isInside(player))
                    {
                        player.Col = 0;
                    }

                    break;
                default:
                    break;
            }
        }

        private static bool isInside(Player player)
        {
            return player.Row >= 0 && player.Row < matrix.Length
                && player.Col >= 0 && player.Col < matrix[player.Row].Length;
        }

        private static void CreateBoard()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[matrix.Length];

                var line = Console.ReadLine()
                    .ToCharArray();

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    char currentSymbol = line[col];
                    matrix[row][col] = currentSymbol;

                    if (currentSymbol == playerOne.Symbol)
                    {
                        playerOne.Row = row;
                        playerOne.Col = col;
                    }
                    else if (currentSymbol == playerTwo.Symbol)
                    {
                        playerTwo.Row = row;
                        playerTwo.Col = col;
                    }
                }
            }
        }
    }
}
