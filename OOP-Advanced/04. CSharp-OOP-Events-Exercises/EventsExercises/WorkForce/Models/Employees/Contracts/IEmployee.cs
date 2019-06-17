namespace WorkForce.Models.Employees.Contracts
{
    using WorkForce.Models.Contracts;

    public interface IEmployee : IIdentifyable
    {
        int WorkHoursPerWeek { get; }
    }
}
