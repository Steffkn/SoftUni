namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    using Data;
    using System.Xml.Serialization;
    using System.IO;
    using System.Text;
    using TeisterMask.Data.Models;
    using TeisterMask.DataProcessor.ImportDto;
    using System.Globalization;
    using TeisterMask.Data.Models.Enums;
    using Newtonsoft.Json;
    using AutoMapper;
    using System.Linq;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";
        private const string DateFormat = "dd/MM/yyyy";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            var sb = new StringBuilder();
            var serializer = new XmlSerializer(typeof(ProjectImportDTO[]), new XmlRootAttribute("Projects"));
            var projects = new List<Project>();

            var deserializationResult = (ProjectImportDTO[])serializer.Deserialize(new StringReader(xmlString));

            foreach (var projectResult in deserializationResult)
            {
                var project = new Project();
                try
                {
                    project.Name = projectResult.Name;
                    project.OpenDate = DateTime.ParseExact(projectResult.OpenDate, DateFormat, CultureInfo.InvariantCulture);
                    if (!string.IsNullOrEmpty(projectResult.DueDate))
                    {
                        project.DueDate = DateTime.ParseExact(projectResult.DueDate, DateFormat, CultureInfo.InvariantCulture);
                    }
                }
                catch (Exception ex)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }


                if (IsValid(project))
                {
                    project.Tasks = new List<Task>();
                    foreach (var taskResult in projectResult.Tasks)
                    {
                        var newTask = new Task();
                        try
                        {
                            newTask.Name = taskResult.Name;
                            newTask.OpenDate = DateTime.ParseExact(taskResult.OpenDate, DateFormat, CultureInfo.InvariantCulture);
                            newTask.DueDate = DateTime.ParseExact(taskResult.DueDate, DateFormat, CultureInfo.InvariantCulture);
                            newTask.ExecutionType = (ExecutionType)taskResult.ExecutionType;
                            newTask.LabelType = (LabelType)taskResult.LabelType;

                            if (project.DueDate.HasValue
                                && (project.DueDate.Value < newTask.DueDate
                                || project.DueDate.Value < newTask.OpenDate))
                            {
                                sb.AppendLine(ErrorMessage);
                                continue;
                            }

                            if (IsValid(newTask)
                                && project.OpenDate.CompareTo(newTask.OpenDate) <= 0
                                && project.OpenDate.CompareTo(newTask.DueDate) <= 0)
                            {
                                newTask.Project = project;
                                project.Tasks.Add(newTask);
                            }
                            else
                            {
                                sb.AppendLine(ErrorMessage);

                                continue;
                            }

                        }
                        catch (Exception ex)
                        {
                            sb.AppendLine(ErrorMessage);

                            continue;
                        }
                    }

                    sb.AppendLine(string.Format(SuccessfullyImportedProject, project.Name, project.Tasks.Count));
                    projects.Add(project);
                }

                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Projects.AddRange(projects);
            context.SaveChanges();


            return sb.ToString().TrimEnd();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var sb = new StringBuilder();

            var deserializationResult = JsonConvert.DeserializeObject<EmployeeDTO[]>(jsonString);
            var employees = new List<Employee>();

            foreach (var result in deserializationResult)
            {
                var employee = new Employee()
                {
                    Username = result.Username,
                    Email = result.Email,
                    Phone = result.Phone
                };

                if (IsValid(employee))
                {
                    employee.EmployeesTasks = new List<EmployeeTask>();
                    foreach (var taskId in result.Tasks.Distinct())
                    {
                        var task = context.Tasks.FirstOrDefault(t => t.Id == taskId);
                        if (task == null)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                        var employeeTask = new EmployeeTask()
                        {
                            Employee = employee,
                            TaskId = taskId
                        };

                        employee.EmployeesTasks.Add(employeeTask);
                    }

                    employees.Add(employee);
                    sb.AppendLine(string.Format(SuccessfullyImportedEmployee, employee.Username, employee.EmployeesTasks.Count));
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Employees.AddRange(employees);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}