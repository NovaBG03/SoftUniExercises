namespace InfernoInfinity.Core
{
    using InfernoInfinity.Contracts;

    public class Engine : IRunnable
    {
        private ICommandInterpreter commandInterpreter;
        private IReader reader;

        public Engine(ICommandInterpreter commandInterpreter, IReader reader)
        {
            this.commandInterpreter = commandInterpreter;
            this.reader = reader;
        }

        public void Run()
        {
            while (true)
            {
                var input = reader.ReadLine().Split(";");

                var commandName = input[0];

                var command = this.commandInterpreter.InterpretCommand(input, commandName);

                command.Execute(input);
            }
        }


    }
}
