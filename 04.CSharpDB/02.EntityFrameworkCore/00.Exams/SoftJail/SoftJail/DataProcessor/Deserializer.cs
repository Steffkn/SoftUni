namespace SoftJail.DataProcessor
{
    using AutoMapper;
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
        private const string ErrorMessage = "Invalid Data";
        private const string SuccessfulImportDepartments
            = "Imported {0} with {1} cells";
        private const string SuccessfulImportPrisoners
            = "Imported {0} {1} years old";
        private const string SuccessfulImportOfficers
            = "Imported {0} ({1} prisoners)";

        private static bool IsValid(object obj)
        {
            var validator = new System.ComponentModel.DataAnnotations.ValidationContext(obj);
            var validationResult = new List<ValidationResult>();

            var res = Validator.TryValidateObject(obj, validator, validationResult, true);

            //if (validationResult.Count > 0)
            //{
            //    Console.WriteLine(string.Join('|', validationResult.Select(x => x.ErrorMessage)));
            //}
            return res;
        }

        public static string ImportDepartmentsCells(SoftJailDbContext context, string jsonString)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var deserializedObjects = JsonConvert.DeserializeObject<List<Department>>(jsonString, serializerSettings);

            var departments = new List<Department>();
            var sb = new StringBuilder();

            foreach (var obj in deserializedObjects)
            {
                if (IsValid(obj))
                {
                    foreach (var cell in obj.Cells)
                    {
                        cell.Department = obj;
                    }

                    if (obj.Cells.All(c => IsValid(c)))
                    {
                        departments.Add(obj);
                        sb.AppendFormat(SuccessfulImportDepartments, obj.Name, obj.Cells.Count);
                        sb.AppendLine();
                    }
                    else
                    {
                        sb.AppendLine(ErrorMessage);
                    }
                }
                else
                {
                    sb.AppendLine(ErrorMessage);
                }
            }

            context.Departments.AddRange(departments);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportPrisonersMails(SoftJailDbContext context, string jsonString)
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                NullValueHandling = NullValueHandling.Ignore
            };

            var deserializedObjects = JsonConvert.DeserializeObject<List<PrisonerDTO>>(jsonString, serializerSettings);

            var prisoners = new List<Prisoner>();
            var sb = new StringBuilder();

            foreach (var result in deserializedObjects)
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
            var serializer = new XmlSerializer(typeof(OfficerDTO[]), new XmlRootAttribute("Officers"));
            var deserializationResult = (OfficerDTO[])serializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var officers = new List<Officer>();

            foreach (var result in deserializationResult)
            {
                var officer = new Officer()
                {
                    FullName = result.Name,
                    Salary = result.Money
                };

                var IsPositionValid = Enum.IsDefined(typeof(Position), result.SomePosition);

                var IsWeaponValid = Enum.IsDefined(typeof(Weapon), result.SomeWeapon);

                var IsDepartmentValid = context.Departments.Any(d => d.Id == result.DepartmentId);

                if (IsPositionValid && IsWeaponValid && IsDepartmentValid)
                {
                    officer.Position = (Position)Enum.Parse(typeof(Position), result.SomePosition);
                    officer.Weapon = (Weapon)Enum.Parse(typeof(Weapon), result.SomeWeapon); ;
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
                             }).ToHashSet();

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
    }
}