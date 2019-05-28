namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Contracts;

    public class RemoveGemFromWeaponCommand : Command
    {
        private IRepository<IWeapon> weaponRepository;

        public RemoveGemFromWeaponCommand(IRepository<IWeapon> weaponRepository)
        {
            this.weaponRepository = weaponRepository;
        }

        public override void Execute(string[] input)
        {

            var weaponName = input[1];
            var weapon = this.weaponRepository.GetItem(weaponName);

            if (weapon == null)
            {
                return;
            }

            var socketIndex = int.Parse(input[2]);

            weapon.ClearSocket(socketIndex);
        }
    }
}
