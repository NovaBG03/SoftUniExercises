using System;
using System.Linq;

namespace ActionPoint
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Action<string> print = x => Console.WriteLine(x);

            Console.ReadLine()
                .Split()
                .ToList()
                .ForEach(print);
        }
    }
}
