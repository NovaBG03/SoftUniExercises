namespace InfernoInfinity.Contracts
{
    public interface IWeapon : IMegicalStats, IIdentifiable
    {
        int MinDamage { get; }

        int MaxDamage { get; }

        int NumberOfSockets { get; }

        IRarity Raritiy { get; }

        void AddGem(int socketIndex, IGem gem);

        void ClearSocket(int socketIndex);
    }
}
