namespace WorkForce
{
    using System.Collections.Generic;
    using WorkForce.Core;
    using WorkForce.Factories;
    using WorkForce.Models;
    using WorkForce.Models.Employees.Contracts;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            var jobs = new JobList();
            var employees = new List<IEmployee>();
            var employeeFactory = new EmployeeFactory();

            Engine engine = new Engine(jobs, employees, employeeFactory);
            engine.Run();
        }
    }
}
