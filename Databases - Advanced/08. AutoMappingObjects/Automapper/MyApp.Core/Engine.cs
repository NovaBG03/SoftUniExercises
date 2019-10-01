namespace MyApp.Core
{
    using System;

    using MyApp.Core.Contracts;

    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            var input = Console.ReadLine()
                .Split();

            var result = commandInterpreter.Read(input);

            Console.WriteLine(result, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}
