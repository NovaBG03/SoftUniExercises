namespace MyApp.Core.Command
{
    using System;

    using AutoMapper;
    using Contracts;
    using Data;
    using Models;
    using ViewModels;

    public class AddEmployeeCommand : ICommand
    {
        private const string Message = "Employee {0} {1} (${2}) successfully added.";

        private readonly EmployeeContext context;
        private readonly Mapper mapper;

        public AddEmployeeCommand(EmployeeContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            string firstName = args[0];
            string lastName = args[1];
            decimal salary = decimal.Parse(args[2]);

            //TODO validate

            var employee = new Employee()
            {
                FirstName = firstName,
                LastName = lastName,
                Salary = salary
            };

            this.context.Employees.Add(employee);
            this.context.SaveChanges();

            var employeeDto = mapper.CreateMappedObject<EmployeeDto>(employee);

            return string.Format(Message, employeeDto.FirstName, employeeDto.LastName, employeeDto.Salary);
        }
    }
}
