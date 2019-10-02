namespace MyApp.Core.Commands
{
    using System;

    using AutoMapper;
    using Contracts;
    using Data;
    using ViewModels;

    public class EmployeePersonalInfoCommand : ICommand
    {
        private const string Message = "ID: {0} - {1} {2} - ${3:F2}\nBirthday: {4}\nAddress: {5}";
        private const string DateFormat = "dd-MM-yyyy";
        private const string NoInfo = "NO info";
        private readonly EmployeeContext context;
        private readonly Mapper mapper;

        public EmployeePersonalInfoCommand(EmployeeContext context, Mapper mapper)
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

            return string.Format(Message,
                employee.Id,
                employee.FirstName,
                employee.LastName,
                employee.Salary,
                employee.Birthday.HasValue ? employee.Birthday.Value.ToString(DateFormat) : NoInfo,
                employee.Address != null ? employee.Address : NoInfo);
        }
    }
}
