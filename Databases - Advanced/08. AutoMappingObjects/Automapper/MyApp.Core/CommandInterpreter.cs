namespace MyApp.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Command.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";

        public string Read(string[] args)
        {
            var commandName = args.First() + Suffix;

            var commandParams = args.Skip(1).ToArray();

            var commandType = this.GetCommandType(commandName);

            if (commandType == null)
            {
                throw new InvalidOperationException($"Can't find {commandName}");
            }

            var command = CreateCommandInstance(commandType);

            var result = command.Execute(commandParams);

            return result;
        }

        private static ICommand CreateCommandInstance(Type commandType)
        {
            var constructor = commandType
                .GetConstructors()
                .First();

            var constructorParamTypes = constructor
                .GetParameters()
                .Select(p => p.ParameterType)
                .ToArray();

            //constructorParamTypes => services

            //invoke ctor with services

            //return command
        }

        private Type GetCommandType(string commandName)
        {
            var commandType = Assembly
                .GetCallingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == commandName);

            return commandType;
        }
    }
}
