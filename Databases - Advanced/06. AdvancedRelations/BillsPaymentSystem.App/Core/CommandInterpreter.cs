namespace BillsPaymentSystem.App.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Commands.Contracts;
    using Contracts;
    using Data;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";

        public string Interpret(string[] args, BillsPaymentSystemContext context)
        {
            string commandName = args.First() + Suffix;
            var commandArgs = args.Skip(1).ToArray();

            var commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName);

            if (commandType == null)
            {
                throw new InvalidOperationException($"Can't find {commandName}");
            }

            var command = (ICommand)Activator
                .CreateInstance(commandType, new object[] { context });

            var result = command.Execute(commandArgs);

            return result;
        }
    }
}
