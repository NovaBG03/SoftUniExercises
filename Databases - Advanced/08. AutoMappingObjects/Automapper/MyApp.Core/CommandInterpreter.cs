namespace MyApp.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using Contracts;
    using Commands.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string Suffix = "Command";

        private readonly IServiceProvider serviceProvider;

        public CommandInterpreter(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

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

        private ICommand CreateCommandInstance(Type commandType)
        {
            var constructor = commandType
                .GetConstructors()
                .First();

            var constructorParamTypes = constructor
                .GetParameters()
                .Select(p => p.ParameterType);

            var constructorParamInstances = constructorParamTypes
                .Select(t => this.serviceProvider.GetService(t))
                .ToArray();

            var command = (ICommand)constructor.Invoke(constructorParamInstances);

            return command;
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
