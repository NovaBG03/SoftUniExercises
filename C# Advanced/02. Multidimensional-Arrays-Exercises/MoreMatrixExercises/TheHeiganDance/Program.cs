using System;
using System.Collections.Generic;

namespace TheHeiganDance
{
    class Program
    {
        private static bool[][] chamber;
        private static int playerRow;
        private static int playerCol;
        private static decimal playerHealth;
        private static decimal bossHealth;
        private static Queue<int[]> cloudsCells;
        private static Queue<int[]> EruptionCells;
        private static bool isCloudsFromBefore;

        static void Main(string[] args)
        {
            playerRow = 7;
            playerCol = 7;

            playerHealth = 18500;
            bossHealth = 3000000;

            cloudsCells = new Queue<int[]>(9);
            EruptionCells = new Queue<int[]>(9);

            InitialiseChamber();

            int playerDamage = int.Parse(Console.ReadLine());

            while (true)
            {
                string[] spellInput = Console.ReadLine().Split();
                string spell = spellInput[0];
                int spellRow = int.Parse(spellInput[1]);
                int spellCol = int.Parse(spellInput[2]);

                switch (spell)
                {
                    case "Cloud":
                        CastCloud(spellRow, spellCol);
                        break;
                    case "Eruption":
                        CastEruption(spellRow, spellCol);
                        break;
                    default:
                        break;
                }


            }


        }

        private static void CastEruption(int spellRow, int spellCol)
        {
            for (int currentRow = spellRow - 1; currentRow <= spellRow + 1; currentRow++)
            {
                for (int currentCol = spellCol - 1; currentCol <= spellCol + 1; currentCol++)
                {
                    EruptionCells.Enqueue(new int[] { currentRow, currentCol });
                }
            }

            if (isPlayerOnEruption())
            {
                PayerMove();
            }
        }

        private static bool isPlayerOnEruption()
        {
            foreach (int[] cell in EruptionCells)
            {
                if (cell[0] == playerRow && cell[1] == playerCol)
                {
                    return true;
                }
            }

            return false;
        }

        private static void CastCloud(int spellRow, int spellCol)
        {
            for (int currentRow = spellRow - 1; currentRow <= spellRow + 1; currentRow++)
            {
                for (int currentCol = spellCol - 1; currentCol <= spellCol + 1; currentCol++)
                {
                    cloudsCells.Enqueue(new int[] { currentRow, currentCol });

                    if (isInsideChamber(currentRow, currentCol))
                    {
                        chamber[currentRow][currentCol] = true;
                    }
                }
            }

            if(chamber[playerRow][playerCol])
            {
                PayerMove();
            }

            if (chamber[playerRow][playerCol])
            {
                if (isCloudsFromBefore)
                {
                    DealCloudDamage();
                    RemoveOldClouds();
                }

                DealCloudDamage();
            }

            isCloudsFromBefore = true;
        }

        private static void RemoveOldClouds()
        {
            for (int i = 0; i < 9; i++)
            {
                cloudsCells.Dequeue();
            }

            isCloudsFromBefore = false;
        }

        private static void DealCloudDamage()
        {
            for (int i = 0; i < 9; i++)
            {
                int[] currentCloud = cloudsCells.Dequeue();

                if (playerRow == currentCloud[0] && playerCol == currentCloud[1])
                {
                    playerHealth -= 3500;
                }
            }

            isCloudsFromBefore = false;
        }

        private static void PayerMove()
        {
            if (isInsideChamber(playerRow - 1, playerCol) && !chamber[playerRow - 1][playerCol])
            {
                playerRow--;
            }
            else if (isInsideChamber(playerRow, playerCol + 1) && !chamber[playerRow][playerCol + 1])
            {
                playerCol++;
            }
            else if (isInsideChamber(playerRow + 1, playerCol) && !chamber[playerRow + 1][playerCol])
            {
                playerRow++;
            }
            else if (isInsideChamber(playerRow, playerCol - 1) && !chamber[playerRow][playerCol - 1])
            {
                playerCol--;
            }
        }

        private static bool isInsideChamber(int row, int col)
        {
            return row >= 0
                && row < chamber.Length
                && col >= 0
                && col < chamber[0].Length;
        }

        private static void InitialiseChamber()
        {
            chamber = new bool[15][];

            for (int row = 0; row < chamber.Length; row++)
            {
                chamber[row] = new bool[15];
            }
        }
    }
}
