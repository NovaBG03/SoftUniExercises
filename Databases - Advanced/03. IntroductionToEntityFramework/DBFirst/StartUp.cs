using Microsoft.EntityFrameworkCore;
using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var result = RemoveTown(context);
                Console.WriteLine(result);
            }
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.FirstName)
                .Where(e => e.Salary > 50000)
                .Select(e => new {
                    e.FirstName,
                    e.Salary
                })
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} - {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .OrderBy(e => e.EmployeeId)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} {employee.MiddleName} {employee.JobTitle} {employee.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .OrderBy(e => e.Salary)
                .ThenBy(e => e.FirstName)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} from {employee.DepartmentName} - ${employee.Salary:F2}");
            }

            string name = "ivan";

            name = name + " ivanov";

            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var address = new Address
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            var employee = context.Employees
                .First(e => e.LastName == "Nakov");
            employee.Address = address;

            context.SaveChanges();

            var addressTexts = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Select(e => e.Address.AddressText)
                .Take(10)
                .ToArray();

            foreach (var addressText in addressTexts)
            {
                sb.AppendLine(addressText);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e =>
                    e.EmployeesProjects.Any(p =>
                        p.Project.StartDate.Year >= 2001 &&
                        p.Project.StartDate.Year <= 2003))
                .Select(e => new
                {
                    FullName = e.FirstName + " " + e.LastName,
                    ManagerFullName = e.Manager.FirstName + " " + e.Manager.LastName,
                    Projects = e.EmployeesProjects.Select(p => new
                    {
                        p.Project.Name,
                        p.Project.StartDate,
                        p.Project.EndDate
                    }).ToArray()
                })
                .Take(10)
                .ToArray();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FullName} - Manager: {employee.ManagerFullName}");

                foreach (var project in employee.Projects)
                {
                    var startDate = project.StartDate.ToString("M/d/yyyy h:mm:ss tt");

                    var endDate = project.EndDate?.ToString("M/d/yyyy h:mm:ss tt");
                    if (endDate == null)
                    {
                        endDate = "not finished";
                    }


                    sb.AppendLine($"--{project.Name} - {startDate} - {endDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var addresses = context.Addresses
                .OrderByDescending(a => a.Employees.Count())
                .ThenBy(a => a.Town.Name)
                .ThenBy(a => a.AddressText)
                .Take(10)
                .Select(a => new
                {
                    a.AddressText,
                    TownName = a.Town.Name,
                    EmployeeCount = a.Employees.Count()
                })
                .ToList();

            foreach (var address in addresses)
            {
                sb.AppendLine($"{address.AddressText}, {address.TownName} - {address.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employee = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    FullName = e.FirstName + " " + e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                        .OrderBy(p => p.Project.Name)
                        .Select(p => new
                        {
                            p.Project.Name
                        })
                        .ToArray()
                })
                .First();

            sb.AppendLine($"{employee.FullName} - {employee.JobTitle}");
            foreach (var project in employee.Projects)
            {
                sb.AppendLine(project.Name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var departments = context.Departments
                .Where(d => d.Employees.Count() > 5)
                .OrderBy(d => d.Employees.Count())
                .ThenBy(d => d.Name)
                .Select(d => new
                {
                    d.Name,
                    ManagerName = d.Manager.FirstName + " " + d.Manager.LastName,
                    Employees = d.Employees
                        .OrderBy(e => e.FirstName)
                        .ThenBy(e => e.LastName)
                        .Select(e => new
                        {
                            Name = e.FirstName + " " + e.LastName,
                            e.JobTitle
                        })
                        .ToArray()
                })
                .ToArray();

            foreach (var department in departments)
            {
                sb.AppendLine($"{department.Name} - {department.ManagerName}");

                foreach (var employee in department.Employees)
                {
                    sb.AppendLine($"{employee.Name} - {employee.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }
        public static string GetLatestProjects(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var projects = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    StartDate = p.StartDate.ToString("M/d/yyyy h:mm:ss tt")
                })
                .ToArray()
                .OrderBy(p => p.Name);

            foreach (var project in projects)
            {
                sb.AppendLine(project.Name);
                sb.AppendLine(project.Description);
                sb.AppendLine(project.StartDate);
            }

            return sb.ToString().TrimEnd();
        }

        public static string IncreaseSalaries(SoftUniContext context)
        {
            string[] departmentNames = { "Engineering", "Tool Design", "Marketing", "Information Services" };
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => departmentNames.Contains(e.Department.Name))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            employees.ForEach(e => e.Salary += (decimal)0.12 * e.Salary);

            context.SaveChanges();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FirstName} {employee.LastName} (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Select(e => new
                {
                    FullName = e.FirstName + " " + e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .ToList();

            foreach (var employee in employees)
            {
                sb.AppendLine($"{employee.FullName} - {employee.JobTitle} - (${employee.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        public static string DeleteProjectById(SoftUniContext context)
        {
            var sb = new StringBuilder();

            var project = context.Projects
                .Find(2);
            context.Projects.Remove(project);

            var employeesProjects = context.EmployeesProjects
                .Where(ep => ep.Project == project)
                .ToList();
            context.EmployeesProjects.RemoveRange(employeesProjects);

            context.SaveChanges();

            var projectNames = context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList();

            foreach (var name in projectNames)
            {
                sb.AppendLine(name);
            }

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTown(SoftUniContext context)
        {
            var town = context.Towns
                .FirstOrDefault(t => t.Name == "Seattle");

            var addresses = context.Addresses
                .Where(a => a.Town == town)
                .ToArray();

            context.Employees
                .Where(e => addresses.Contains(e.Address))
                .ToList()
                .ForEach(e => e.Address = null);
            context.SaveChanges();

            context.Addresses.RemoveRange(addresses);
            var removedAddressesCount = context.SaveChanges();

            context.Towns.Remove(town);
            context.SaveChanges();

            return $"{removedAddressesCount} addresses in Seattle were deleted";
        }
    }
}
