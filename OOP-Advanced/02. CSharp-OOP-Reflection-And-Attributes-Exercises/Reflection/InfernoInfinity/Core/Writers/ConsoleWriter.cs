using InfernoInfinity.Contracts;
using System;

namespace InfernoInfinity.Core.Writers
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string output)
        {
            Console.WriteLine(output);
        }
    }
}
