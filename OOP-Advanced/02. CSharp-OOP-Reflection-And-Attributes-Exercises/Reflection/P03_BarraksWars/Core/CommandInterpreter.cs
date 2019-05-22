using _03BarracksFactory.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core
{
    class CommandInterpreter : ICommandInterpreter
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public CommandInterpreter(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(x => x.Name.ToLower().Contains("command")
                        && x.Name.ToLower().Contains(commandName))
                .FirstOrDefault();

            if (commandType == null)
            {
                new InvalidOperationException("Invalid command!");
            }

            var fields = commandType
                .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .Where(f => f.CustomAttributes
                    .Any(a => a.AttributeType == typeof(CustomAttributes.InjectAttribute)))
                .ToArray();

            object[] arg = new object[fields.Length + 1];

            arg[0] = data;

            for (int i = 0; i < fields.Length; i++)
            {
                var currentFieldType = fields[i].FieldType;

                var currentFieldValue = this
                    .GetType()
                    .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                    .Where(f => f.FieldType == currentFieldType)
                    .First()
                    .GetValue(this);

                arg[i + 1] = currentFieldValue;
            }


            var instace = (IExecutable)Activator.CreateInstance(commandType, arg);

            return instace;
        }
    }
}
