namespace MyApp.Core.Commands
{
    using System;

    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    public class SetManagerCommand : ICommand
    {
        private const string Message = "{0} {1} set as manager to {2} {3}.";

        private readonly EmployeeContext context;
        private readonly Mapper mapper;

        public SetManagerCommand(EmployeeContext context, Mapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public string Execute(string[] args)
        {
            int employeeId = int.Parse(args[0]);
            int managerId = int.Parse(args[1]);

            var employee = this.context.Employees.Find(employeeId);
            var manager = this.context.Employees.Find(managerId);

            if (employee == null)
            {
                throw new ArgumentException("Invalid employee Id");
            }

            if (manager == null)
            {
                throw new ArgumentException("Invalid manager Id");
            }

            employee.Manager = manager;
            this.context.SaveChanges();

            var employeeDto = mapper.CreateMappedObject<EmployeeSalaryDto>(employee);
            var managerDto = mapper.CreateMappedObject<ManagerDto>(manager);

            return string.Format(Message, managerDto.FirstName, managerDto.LastName, employeeDto.FirstName, employeeDto.LastName);
        }
    }
}
