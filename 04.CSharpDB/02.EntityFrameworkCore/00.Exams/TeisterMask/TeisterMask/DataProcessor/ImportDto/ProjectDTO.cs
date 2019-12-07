using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ImportDto
{
    [XmlType("Project")]
    public class ProjectImportDTO
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }

        [XmlArray("Tasks")]
        public TaskImportDTO[] Tasks { get; set; }
    }

    [XmlType("Task")]
    public class TaskImportDTO
    {
        [XmlElement("Name")]
        public string Name { get; set; }

        [XmlElement("OpenDate")]
        public string OpenDate { get; set; }

        [XmlElement("DueDate")]
        public string DueDate { get; set; }


        [XmlElement("ExecutionType")]
        public int ExecutionType { get; set; }
        [XmlElement("LabelType")]
        public int LabelType { get; set; }
    }

    //[XmlType("Customer")]
    //public class CustomerImportDTO
    //{
    //    [XmlElement("FirstName")]
    //    public string FirstName { get; set; }

    //    [XmlElement("LastName")]
    //    public string LastName { get; set; }

    //    [XmlElement("Age")]
    //    public int Age { get; set; }

    //    [XmlElement("Balance")]
    //    public decimal Balance { get; set; }

    //    [XmlArray("Tickets")]
    //    public TicketImportDTO[] Tickets { get; set; }
    //}

    //[XmlType("Ticket")]
    //public class TicketImportDTO
    //{
    //    [XmlElement("ProjectionId")]
    //    public int ProjectionId { get; set; }

    //    [XmlElement("Price")]
    //    public decimal Price { get; set; }
    //}
}
