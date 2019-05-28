namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Contracts;

    public class PrintWeaponCommand : Command
    {
        private IRepository<IWeapon> weaponRepository;
        private IWriter writer;

        public PrintWeaponCommand(IRepository<IWeapon> weaponRepository, IWriter writer)
        {
            this.weaponRepository = weaponRepository;
            this.writer = writer;
        }

        public override void Execute(string[] input)
        {
            var weaponName = input[1];
            var weapon = this.weaponRepository.GetItem(weaponName);

            if (weapon == null)
            {
                return;
            }

            this.writer.WriteLine(weapon.ToString());
        }
    }
}
