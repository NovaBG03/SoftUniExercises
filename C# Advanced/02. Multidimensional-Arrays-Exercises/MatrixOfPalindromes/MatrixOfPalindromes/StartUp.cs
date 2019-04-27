using System;
using System.Linq;

namespace MatrixOfPalindromes
{
    class StartUp
    {
        static void Main(string[] args)
        {
            char[] alphabet = "abcdefghijklmnopqrstuvwxyz".ToCharArray();

            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string[][] matrix = new string[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[cols];

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    string palindrome = $"{alphabet[row]}{alphabet[row + col]}{alphabet[row]}";
                    matrix[row][col] = palindrome;
                }
            }

            for (int row = 0; row < matrix.Length; row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }
    }
}
