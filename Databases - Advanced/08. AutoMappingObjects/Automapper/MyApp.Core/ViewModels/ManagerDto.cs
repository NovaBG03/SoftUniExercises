namespace MyApp.Core.ViewModels
{
    using System;
    using System.Collections.Generic;

    using Models;

    public class ManagerDto
    {
        public ManagerDto()
        {
            this.Employees = new HashSet<Employee>();
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public HashSet<Employee> Employees { get; set; }

        public int EmployeesCount
            => this.Employees.Count;
    }
}
