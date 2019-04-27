using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomMinFunction
{
    public class StartUp
    {
        private static Func<IEnumerable<int>, int> getMinInt = x =>
        {
            int min = int.MaxValue;

            foreach (var n in x)
            {
                if (n < min)
                {
                    min = n;
                }
            }

            return min;
        };

        public static void Main(string[] args) => Console.WriteLine(
                getMinInt(Console.ReadLine()
                    .Split()
                    .Select(int.Parse)));
    }
}
