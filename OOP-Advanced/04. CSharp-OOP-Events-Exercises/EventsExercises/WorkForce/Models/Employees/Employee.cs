namespace WorkForce.Models.Employees
{
    using WorkForce.Models.Employees.Contracts;

    public abstract class Employee : IEmployee
    {
        protected Employee(string name, int workHoursPerWeek)
        {
            Name = name;
            WorkHoursPerWeek = workHoursPerWeek;
        }

        public string Name { get; private set; }

        public int WorkHoursPerWeek { get; private set; }
}
}
