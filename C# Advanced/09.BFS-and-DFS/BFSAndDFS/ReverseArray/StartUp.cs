using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseArray
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split().ToList();

            Print(list, 0);
        }

        private static void Print(List<string> list, int index)
        {
            if (index >= list.Count)
            {
                return;
            }

            Print(list, index + 1);

            Console.Write(list[index] + " ");
        }
    }
}
