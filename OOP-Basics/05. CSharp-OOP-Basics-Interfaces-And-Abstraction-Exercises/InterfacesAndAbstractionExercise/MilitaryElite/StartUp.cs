using MilitaryElite.Core;
using System;

namespace MilitaryElite
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Engine engine = new Engine();
            engine.Run();
            Console.ReadKey();
        }
    }
}
