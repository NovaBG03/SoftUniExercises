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

    public class ListEmployeesOlderThanCommand : ICommand
    {
        private const string Message = "{0} {1} - ${2:F2} - Manager: {3}";
        private const string NoEmployeesMessage = "No employees found.";
        private const string NoManagerString = "[no manager]";

        private readonly EmployeeContext context;
        private readonly Mapper mapper;

        public ListEmployeesOlderThanCommand(EmployeeContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            int minAge = int.Parse(args[0]);

            var employees = context.Employees
                .Include(e => e.Manager)
                .Where(e => e.Birthday.HasValue
                    && e.Birthday.Value.Year > minAge)
                .OrderBy(e => e.Salary)
                .ToList();

            if (employees.Count == 0)
            {
                return NoEmployeesMessage;
            }

            var formatedEmployees = employees
                .Select(e => string.Format(
                    Message,
                    e.FirstName,
                    e.LastName,
                    e.Salary,
                    e.Manager?.FirstName ?? NoManagerString
                    ));

            return string.Join("\n", formatedEmployees);
        }
    }
}
