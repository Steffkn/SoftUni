using SoftJail.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace SoftJail.DataProcessor.ImportDto
{
    [XmlType("Officer")]
    public class OfficerDTO
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Money")]
        public decimal Money { get; set; }

        [XmlElement("DepartmentId")]
        public int DepartmentId { get; set; }

        [XmlIgnore]
        public Position? Position { get; set; }

        [XmlElement("Position")]
        public string SomePosition
        {
            get { return this.Position.ToString(); }
            set
            {
                Position posValue;
                if (Enum.TryParse<Position>(value, out posValue))
                {
                    this.Position = posValue;
                }
                else
                {
                    this.Position = null;
                }
            }
        }

        [XmlIgnore]
        public Weapon? Weapon { get; set; }

        [XmlElement("Weapon")]
        public string SomeWeapon
        {
            get { return this.Weapon.ToString(); }
            set
            {
                Weapon posValue;
                if (Enum.TryParse<Weapon>(value, out posValue))
                {
                    this.Weapon = posValue;
                }
                else
                {
                    this.Weapon = null;
                }
            }
        }

        public SimplePrisonerDTO[] Prisoners { get; set; }
    }

    [XmlType("Prisoner")]
    public class SimplePrisonerDTO
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }
    }
}
