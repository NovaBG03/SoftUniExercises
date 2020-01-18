namespace TeisterMask.DataProcessor
{
    using System;
    using System.Linq;
    using Data;
    using TeisterMask.DataProcessor.ExportDto;
    using Newtonsoft.Json;
    using Formatting = Newtonsoft.Json.Formatting;
    using System.Text;
    using System.IO;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(p => p.Tasks.Any())
                .OrderByDescending(p => p.Tasks.Count)
                .ThenBy(p => p.Name)
                .Select(p => new ProjectExpoerDto()
                {
                    TasksCount = p.Tasks.Count.ToString(),
                    ProjectName = p.Name,
                    HasEndDate = p.DueDate != null ? "Yes" : "No",
                    Tasks = p.Tasks
                        .OrderBy(t => t.Name)
                        .Select(t => new TaskSecondExportDto()
                        {
                            Name = t.Name,
                            Label = t.LabelType.ToString()
                        })
                        .ToList()
                })
                .ToArray();

            var xns = new XmlSerializerNamespaces();
            xns.Add("", "");

            var serializer = new XmlSerializer(projects.GetType(), new XmlRootAttribute("Projects"));

            var result = new StringBuilder();

            using (var stream = new StringWriter(result))
            {
                serializer.Serialize(stream, projects, xns);
            }

            return result.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(e => e.EmployeesTasks.Any(t => t.Task.OpenDate >= date))
                .OrderByDescending(e => e.EmployeesTasks.Count)
                .ThenBy(e => e.Username)
                .Take(10)
                .Select(e => new EmployeeExportDto()
                {
                    Username = e.Username,
                    Tasks = e.EmployeesTasks
                        .Where(t => t.Task.OpenDate >= date)
                        .OrderByDescending(et => et.Task.DueDate)
                        .ThenBy(et => et.Task.Name)
                        .Select(et => new TaskExportDto()
                        {
                            TaskName = et.Task.Name,
                            OpenDate = et.Task.OpenDate.ToString("MM/dd/yyyy"),
                            DueDate = et.Task.DueDate.ToString("MM/dd/yyyy"),
                            LabelType = et.Task.LabelType.ToString(),
                            ExecutionType = et.Task.ExecutionType.ToString()
                        })
                        .ToList()
                });

            var serializer = new JsonSerializer();

            var result = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return result;
        }
    }
}