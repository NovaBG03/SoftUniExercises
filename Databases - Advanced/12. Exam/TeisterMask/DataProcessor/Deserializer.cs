namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;
    using System.Globalization;
    using Newtonsoft.Json;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using TeisterMask.DataProcessor.ImportDto;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var serializer = new XmlSerializer(typeof(ProjectImportDto[]), new XmlRootAttribute("Projects"));

            ProjectImportDto[] projectDtos;
            using (var stream = new StringReader(xmlString))
            {
                projectDtos = (ProjectImportDto[])serializer.Deserialize(stream);
            }

            var resultBuilder = new StringBuilder();

            foreach (var projectDto in projectDtos)
            {
                var project = new Project
                {
                    Name = projectDto.Name,
                    OpenDate = DateTime.ParseExact(projectDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    DueDate = ParseDateTime(projectDto.DueDate)
                };

                if (!IsValid(project))
                {
                    resultBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var taskDto in projectDto.Tasks)
                {
                    var task = new Task();
                    task.Name = taskDto.Name;
                    task.OpenDate = DateTime.ParseExact(taskDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    task.DueDate = DateTime.ParseExact(taskDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    task.ExecutionType = (ExecutionType)Enum.ToObject(typeof(ExecutionType), taskDto.ExecutionType);
                    task.LabelType = (LabelType)Enum.ToObject(typeof(LabelType), taskDto.LabelType);


                    if (!IsValid(task)
                        || task.OpenDate > project.OpenDate
                        || task.DueDate < project.DueDate)
                    {
                        resultBuilder.AppendLine(ErrorMessage);
                        continue;
                    }
                    
                    project.Tasks.Add(task);
                }

                context.Projects.Add(project);
                resultBuilder.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
            }

            context.SaveChanges();

            var result = resultBuilder.ToString().TrimEnd();
            return result;
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var serializer = new JsonSerializer();

            EmployeeImportDto[] employeeDtos;
            using (var stream = new StringReader(jsonString))
            {
                employeeDtos = (EmployeeImportDto[])serializer.Deserialize(stream, typeof(EmployeeImportDto[]));
            }

            var resultBuilder = new StringBuilder();

            foreach (var employeeDto in employeeDtos)
            {
                var employee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone
                };

                if (!IsValid(employee))
                {
                    resultBuilder.AppendLine(ErrorMessage);
                    continue;
                }

                foreach (var taskId in employeeDto.Tasks.Distinct())
                {
                    var currentTask = context.Tasks.Find(taskId);
                    if (currentTask == null)
                    {
                        resultBuilder.AppendLine(ErrorMessage);
                        continue;
                    }

                    var employeeTask = new EmployeeTask()
                    {
                        TaskId = taskId,
                    };

                    employee.EmployeesTasks.Add(employeeTask);
                }

                context.Employees.Add(employee);
                resultBuilder.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
            }

            context.SaveChanges();

            var result = resultBuilder.ToString().TrimEnd();
            return result;
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static DateTime? ParseDateTime(string date)
        {
            try
            {
                return DateTime.ParseExact(date, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}