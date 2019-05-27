namespace InfernoInfinity.Contracts
{
    public interface IWeaponFactory
    {
        IWeapon CreateWeapon(string typeAsString, string name, IRarity raritiy);
    }
}
