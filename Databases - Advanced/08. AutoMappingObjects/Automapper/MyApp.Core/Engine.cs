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
            while (true)
            {
                var input = Console.ReadLine()
                    .Split();

                try
                {
                    var result = commandInterpreter.Read(input);

                    Console.WriteLine(result, StringSplitOptions.RemoveEmptyEntries);
                }
                catch (Exception)
                {
                    Console.WriteLine("Error Or Invalid Command");
                }

            }
        }
    }
}
