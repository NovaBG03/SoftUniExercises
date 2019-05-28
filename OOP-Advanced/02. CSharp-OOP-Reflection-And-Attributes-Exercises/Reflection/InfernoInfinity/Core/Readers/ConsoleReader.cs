using InfernoInfinity.Contracts;
using System;

namespace InfernoInfinity.Core.Readers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            var input = Console.ReadLine();

            return input;
        }
    }
}
