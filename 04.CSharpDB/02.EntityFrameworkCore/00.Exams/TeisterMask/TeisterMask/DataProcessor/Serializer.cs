namespace TeisterMask.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.DataProcessor.ExportDto;
    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportProjectWithTheirTasks(TeisterMaskContext context)
        {
            var projects = context.Projects
                .Where(p => p.Tasks.Any())
                .Select(p => new ProjectExportDTO()
                {
                    Name = p.Name,
                    TasksCount = p.Tasks.Count,
                    HasEndDate = p.DueDate.HasValue ? "Yes" : "No",
                    Tasks = p.Tasks.Select(t => new TaskExportDTO()
                    {
                        Label = t.LabelType.ToString(),
                        Name = t.Name
                    })
                                        .OrderBy(tt => tt.Name)
                                        .ToArray()
                })
                .OrderByDescending(t => t.TasksCount)
                .ThenBy(t => t.Name)
                .ToArray();

            var serializer = new XmlSerializer(typeof(ProjectExportDTO[]), new XmlRootAttribute("Projects"));
            var namespaces = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
            var result = new StringBuilder();

            serializer.Serialize(new StringWriter(result), projects, namespaces);

            return result.ToString().TrimEnd();
        }

        public static string ExportMostBusiestEmployees(TeisterMaskContext context, DateTime date)
        {
            var employees = context.Employees
                .Where(emp => emp.EmployeesTasks.Any(e => e.Task.OpenDate >= date))
                .OrderByDescending(emp => emp.EmployeesTasks.Where(et => et.Task.OpenDate >= date).Count())
                .ThenBy(emp => emp.Username)
                .Select(emp => new
                {
                    emp.Username,
                    Tasks = emp.EmployeesTasks
                                .Select(e => e.Task)
                                .Where(e => e.OpenDate >= date)
                                    .OrderByDescending(t => t.DueDate)
                                    .ThenBy(t => t.Name)
                                    .Select(t => new
                                    {
                                        TaskName = t.Name,
                                        OpenDate = t.OpenDate.ToString("d", CultureInfo.InvariantCulture),
                                        DueDate = t.DueDate.ToString("d", CultureInfo.InvariantCulture),
                                        LabelType = t.LabelType.ToString(),
                                        ExecutionType = t.ExecutionType.ToString()
                                    })
                })
                .Take(10)
                .ToList();


            var result = JsonConvert.SerializeObject(employees, Formatting.Indented);

            return result;
        }
    }
}