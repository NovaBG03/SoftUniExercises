namespace InfernoInfinity.Core.Commands
{
    using InfernoInfinity.Contracts;

    public class CreateWeaponCommand : Command
    {
        private IRepository<IWeapon> weaponRepository;
        private IWeaponFactory weaponFactory;
        private IRarityFactory rarityFactory;

        public CreateWeaponCommand(IRepository<IWeapon> weaponRepository, IWeaponFactory weaponFactory, IRarityFactory rarityFactory)
        {
            this.weaponRepository = weaponRepository;
            this.weaponFactory = weaponFactory;
            this.rarityFactory = rarityFactory;
        }

        public override void Execute(string[] input)
        {
            var weaponInfo = input[1].Split();

            var weaponRarityAsString = weaponInfo[0];
            IRarity weaponRarity = this.rarityFactory.CreateRarity(weaponInfo[0]);

            var weaponTypeAsString = weaponInfo[1];

            var weaponName = input[2];

            var weapon = this.weaponFactory.CreateWeapon(weaponTypeAsString, weaponName, weaponRarity);

            this.weaponRepository.Add(weapon);
        }
    }
}
