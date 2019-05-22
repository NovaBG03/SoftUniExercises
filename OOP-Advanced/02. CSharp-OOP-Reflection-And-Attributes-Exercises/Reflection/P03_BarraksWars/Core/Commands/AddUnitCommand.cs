using _03BarracksFactory.Contracts;
using _03BarracksFactory.CustomAttributes;

namespace _03BarracksFactory.Core.Commands
{
    public class AddUnitCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        [Inject]
        private readonly IUnitFactory unitFactory;

        public AddUnitCommand(string[] data, IRepository repository, IUnitFactory unitFactory)
            : base(data)
        {
            this.unitFactory = unitFactory;
            this.repository = repository;
        }

        public override string Execute()
        {
            string unitType = Data[1];
            IUnit unitToAdd = this.unitFactory.CreateUnit(unitType);
            this.repository.AddUnit(unitToAdd);
            string output = unitType + " added!";
            return output;
        }
    }
}
