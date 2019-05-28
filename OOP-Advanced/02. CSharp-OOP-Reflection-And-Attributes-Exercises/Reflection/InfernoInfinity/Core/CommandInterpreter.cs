namespace InfernoInfinity.Core
{
    using System;
    using System.Linq;
    using System.Reflection;

    using InfernoInfinity.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private IRepository<IWeapon> weaponRepository;
        private IWeaponFactory weaponFactory;
        private IRarityFactory rarityFactory;
        private IGemFactory gemFactory;
        private IClarityFactory clarityFactory;
        private IWriter writer;

        public CommandInterpreter(
            IRepository<IWeapon> weaponRepository, 
            IWeaponFactory weaponFactory, 
            IRarityFactory rarityFactory, 
            IGemFactory gemFactory, 
            IClarityFactory clarityFactory, 
            IWriter writer)
        {
            this.weaponRepository = weaponRepository;
            this.weaponFactory = weaponFactory;
            this.rarityFactory = rarityFactory;
            this.gemFactory = gemFactory;
            this.clarityFactory = clarityFactory;
            this.writer = writer;
        }

        public IExecutable InterpretCommand(string[] data, string commandName)
        {
            var commandType = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.Name.ToLower().Contains("command")
                    && t.Name.ToLower().Contains(commandName.ToLower()))
                .First();

            var consturcotrParameters = commandType
                .GetConstructors()
                .First()
                .GetParameters();

            object[] arg = new object[consturcotrParameters.Length];

            for (int i = 0; i < consturcotrParameters.Length; i++)
            {
                var parameterType = consturcotrParameters[i].ParameterType;

                var fieldValue = this
                    .GetType()
                    .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .First(f => f.FieldType == parameterType)
                    .GetValue(this);

                arg[i] = fieldValue;
            }

            var command = (IExecutable)Activator.CreateInstance(commandType, arg);

            return command;
        }
    }
}
