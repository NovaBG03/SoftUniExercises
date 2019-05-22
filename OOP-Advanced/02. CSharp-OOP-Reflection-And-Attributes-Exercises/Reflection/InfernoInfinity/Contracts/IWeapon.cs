namespace InfernoInfinity.Contracts
{
    public interface IWeapon : IMegicalStats
    {
        string Name { get; }

        int MinDamage { get; }

        int MaxDamage { get; }

        int NumberOfSockets { get; }

        IRaritiy Raritiy { get; }
    }
}
