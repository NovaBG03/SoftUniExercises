using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericBox
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Box<double>> boxes = new List<Box<double>>();

            var boxesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < boxesCount; i++)
            {
                var input = double.Parse(Console.ReadLine());

                Box<double> box = new Box<double>(input);

                boxes.Add(box);
            }

            var lastInput = double.Parse(Console.ReadLine());

            Box<double> lastBox = new Box<double>(lastInput);

            var count = CountOf(lastBox, boxes);

            Console.WriteLine(count);
        }

        private static void Swap<T>(List<T> list, int index1, int index2)
        {
            T swap = list[index1];
            list[index1] = list[index2];
            list[index2] = swap;
        }

        private static int CountOf<T>(T element, List<T> list) where T : IComparable<T>
            => list.Where(x => x.CompareTo(element) == 1).Count();

    }
}
