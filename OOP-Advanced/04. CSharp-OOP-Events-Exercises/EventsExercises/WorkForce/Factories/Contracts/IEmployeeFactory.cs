namespace WorkForce.Factories.Contracts
{
    using WorkForce.Models.Employees.Contracts;

    public interface IEmployeeFactory
    {
        IEmployee CreateEmployee(string typeName, string employeeName);
    }
}
