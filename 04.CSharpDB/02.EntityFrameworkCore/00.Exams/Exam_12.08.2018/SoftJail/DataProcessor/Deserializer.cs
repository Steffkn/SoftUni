namespace SoftJail.DataProcessor
{

    using Data;
    using Newtonsoft.Json;
    using SoftJail.Data.Models;
    using SoftJail.Data.Models.Enums;
    using SoftJail.DataProcessor.ImportDto;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    public class Deserializer
    {
        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var deserializationResult = JsonConvert.DeserializeObject<DepartmentImportDTO[]>(jsonString);
            var departments = new List<Department>();

            foreach (var result in deserializationResult)
            {
                var department = new Department()
                {
                    Name = result.Name
                };

                var cells = new List<Cell>();

                if (IsValid(department))
                {
                    foreach (var cellresult in result.Cells)
                    {


                        var cell = new Cell()
                        {
                            CellNumber = cellresult.CellNumber,
                            HasWindow = cellresult.HasWindow
                        };

                        cells.Add(cell);
                    }

                    if (cells.All(c => IsValid(c)))
                    {
                        foreach (var cell in cells)
                        {
                            department.Cells.Add(cell);
                        }

                        departments.Add(department);
                        sb.AppendLine($"Imported {department.Name} with {department.Cells.Count} cells");
                    }
                    else
                    {
                        sb.AppendLine("Invalid Data");
                    }
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var sb = new StringBuilder();
            var deserializationResult = JsonConvert.DeserializeObject<PrisonerImportDTO[]>(jsonString);
            var prisoners = new List<Prisoner>();

            foreach (var result in deserializationResult)
            {
                var prisoner = new Prisoner()
                {
                    FullName = result.FullName,
                    Nickname = result.Nickname,
                    Age = result.Age,
                    IncarcerationDate = DateTime.ParseExact(result.IncarcerationDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    ReleaseDate = string.IsNullOrEmpty(result.ReleaseDate) ? (DateTime?)null : DateTime.ParseExact(result.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Bail = result.Bail,
                    CellId = context.Cells.Any(c => c.Id == result.CellId) ? result.CellId : -1,
                };

                var mails = new List<Mail>();

                if (IsValid(prisoner))
                {
                    foreach (var mailResult in result.Mails)
                    {
                        var mail = new Mail()
                        {
                            Description = mailResult.Description,
                            Sender = mailResult.Sender,
                            Address = mailResult.Address
                        };

                        mails.Add(mail);
                    }

                    if (mails.All(m => IsValid(m)))
                    {
                        foreach (var mail in mails)
                        {
                            prisoner.Mails.Add(mail);
                        }

                        prisoners.Add(prisoner);
                        sb.AppendLine($"Imported {prisoner.FullName} {prisoner.Age} years old");
                    }
                    else
                    {
                        sb.AppendLine("Invalid Data");
                    }
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }
            }

            context.Prisoners.AddRange(prisoners);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportOfficersPrisoners(SoftJailDbContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var serializer = new XmlSerializer(typeof(OfficerImportDTO[]), new XmlRootAttribute("Officers"));
            var deserializationResult = (OfficerImportDTO[])serializer.Deserialize(new StringReader(xmlString));
            var officers = new List<Officer>();

            foreach (var result in deserializationResult)
            {
                var officer = new Officer()
                {
                    FullName = result.Name,
                    Salary = result.Money
                };

                var IsPositionValid = Enum.IsDefined(typeof(Position), result.Position);

                var IsWeaponValid = Enum.IsDefined(typeof(Weapon), result.Weapon);

                var IsDepartmentValid = context.Departments.Any(d => d.Id == result.DepartmentId);

                if (IsPositionValid && IsWeaponValid && IsDepartmentValid)
                {
                    officer.Position = (Position)Enum.Parse(typeof(Position),result.Position);
                    officer.Weapon = (Weapon)Enum.Parse(typeof(Weapon), result.Weapon); ;
                    officer.DepartmentId = result.DepartmentId;
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                    continue;
                }

                if (IsValid(officer))
                {
                    if (result.Prisoners.All(p => context.Prisoners.Any(pr => pr.Id == p.Id)))
                    {
                        officer.OfficerPrisoners = result.Prisoners
                             .Select(p => new OfficerPrisoner()
                             {
                                 PrisonerId = p.Id
                             }).ToList();

                        officers.Add(officer);
                        sb.AppendLine($"Imported {officer.FullName} ({officer.OfficerPrisoners.Count} prisoners)");
                    }
                    else
                    {
                        sb.AppendLine("Invalid Data");
                    }
                }
                else
                {
                    sb.AppendLine("Invalid Data");
                }
            }

            context.Officers.AddRange(officers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}