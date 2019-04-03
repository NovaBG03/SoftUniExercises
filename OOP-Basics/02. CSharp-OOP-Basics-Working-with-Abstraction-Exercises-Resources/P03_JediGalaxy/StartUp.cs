using System;
using System.Linq;

namespace P03_JediGalaxy
{
    class StartUp
    {
        public int[,] matrix;

        static void Main()
        {
            int[] dimestions = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int x = dimestions[0];
            int y = dimestions[1];

            matrix = new int[x, y];

            Move.FillMatrix(x, y);

            string command = Console.ReadLine();
            long sum = 0;
            while (command != "Let the Force be with you")
            {
                int[] player = command.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int[] evil = Console.ReadLine().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int xE = evil[0];
                int yE = evil[1];

                Move.Evil(xE, yE);

                int xI = player[0];
                int yI = player[1];

                sum += Move.Player(xE, yE);

                command = Console.ReadLine();
            }

            Console.WriteLine(sum);

        }
    }
}
