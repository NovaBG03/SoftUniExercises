using System;
using System.Collections.Generic;
using System.Linq;

namespace ClubParty
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var halls = new Queue<KeyValuePair<char, List<int>>>();

            int maxCapacity = int.Parse(Console.ReadLine());

            var inputStack = new Stack<string>(Console.ReadLine().Split());


            while (true)
            {
                if (inputStack.Count == 0)
                {
                    break;
                }

                if (IsChar(inputStack.Peek()))
                {
                    char hall = char.Parse(inputStack.Pop());

                    halls.Enqueue(new KeyValuePair<char, List<int>>(hall, new List<int>()));
                }
                else
                {
                    int reservation = int.Parse(inputStack.Pop());

                    if (halls.Count == 0)
                    {
                        continue;
                    }

                    if (halls.Peek().Value.Sum() + reservation > maxCapacity)
                    {
                        Print(halls.Dequeue());

                        if (halls.Count == 0)
                        {
                            continue;
                        }
                    }

                    halls.Peek().Value.Add(reservation);
                }
            }
        }

        private static void Print(KeyValuePair<char, List<int>> kvp)
        {
            Console.WriteLine($"{kvp.Key} -> {string.Join(", ", kvp.Value)}");
        }

        private static bool IsChar(string currentElement)
        {
            return currentElement.Length == 1
                && char.IsLetter(char.Parse(currentElement));
        }
    }
}
