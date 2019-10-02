namespace MyApp.Core.Commands
{
    using System;

    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    public class EmployeeInfoCommand : ICommand
    {
        private const string Message = "ID: {0} - {1} {2} - ${3:F2}";

        private readonly EmployeeContext context;
        private readonly Mapper mapper;

        public EmployeeInfoCommand(EmployeeContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);

            var employee = this.context.Employees.Find(employeeId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid employee Id");
            }

            var employeeDto = this.mapper.CreateMappedObject<EmployeeDto>(employee);

            return string.Format(Message,employeeDto.Id, employeeDto.FirstName, employeeDto.LastName, employeeDto.Salary);
        }
    }
}
