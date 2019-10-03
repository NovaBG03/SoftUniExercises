namespace MyApp.Core.Commands
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;
    using System.Text;

    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    public class ManagerInfoCommand : ICommand
    {
        private const string ManagerMessage = "{0} {1} | Employees: {2}";
        private const string EmployeeMessage = "- {0} {1} - ${2:F2}";

        private readonly EmployeeContext context;
        private readonly Mapper mapper;

        public ManagerInfoCommand(EmployeeContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            int managerId = int.Parse(args[0]);

            var manager = this.context.Employees
                .Include(e => e.Employees)
                .Where(e => e.Id == managerId)
                .FirstOrDefault();

            if (manager == null)
            {
                throw new ArgumentException("Invalid manager Id");
            }

            StringBuilder builder = new StringBuilder();
            builder.AppendLine(string.Format(ManagerMessage, manager.FirstName, manager.LastName, manager.Employees.Count));

            foreach (var employee in manager.Employees)
            {
                builder.AppendLine(string.Format(EmployeeMessage, employee.FirstName, employee.LastName, employee.Salary));
            }

            return builder.ToString().TrimEnd();
        }
    }
}
