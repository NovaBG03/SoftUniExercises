using _03BarracksFactory.Contracts;
using _03BarracksFactory.CustomAttributes;

namespace _03BarracksFactory.Core.Commands
{
    public class RetireCommand : Command
    {
        [Inject]
        private readonly IRepository repository;

        public RetireCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.repository = repository;
        }


        public override string Execute()
        {
            string unitType = Data[1];

            this.repository.RemoveUnit(unitType);

            string output = $"{unitType} retired!";
            return output;
        }
    }
}
