namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Contracts;

    public class AddGemToWeaponCommand : Command
    {
        private IRepository<IWeapon> weaponRepository;
        private IGemFactory gemFactory;
        private IClarityFactory clarityFactory;

        public AddGemToWeaponCommand(IRepository<IWeapon> weaponRepository, IGemFactory gemFactory, IClarityFactory clarityFactory)
        {
            this.weaponRepository = weaponRepository;
            this.gemFactory = gemFactory;
            this.clarityFactory = clarityFactory;
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

            var gemInfo = input[3].Split();

            var gemClarityAsString = gemInfo[0];
            var gemClarity = this.clarityFactory.CreateClarity(gemClarityAsString);

            var gemTypeAsString = gemInfo[1];
            var gem = this.gemFactory.CreateGem(gemTypeAsString, gemClarity);

            weapon.AddGem(socketIndex, gem);
        }
    }
}
