namespace WorkForce.Factories
{
    using WorkForce.Factories.Contracts;
    using WorkForce.Models.Employees;
    using WorkForce.Models.Employees.Contracts;

    public class EmployeeFactory : IEmployeeFactory
    {
        public EmployeeFactory()
        {
        }

        public IEmployee CreateEmployee(string typeName, string employeeName)
        {
            switch (typeName)
            {
                case "StandardEmployee":
                    return new StandardEmployee(employeeName);
                case "PartTimeEmployee":
                    return new PartTimeEmployee(employeeName);
                default:
                    return null;
            }
        }
    }
}
