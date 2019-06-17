namespace WorkForce.Models.Contracts
{
    public interface IJob : IIdentifyable
    {
        int WorkHoursRequired { get; }

        void Update();
    }
}
