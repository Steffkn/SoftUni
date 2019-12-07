using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project")]
    public class ProjectExportDTO
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement("ProjectName")]
        public string Name { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }
        //{
        //    get
        //    {
        //        return this.DueDate.HasValue ? "Yes" : "No";
        //    }
        //}

        //public DateTime? DueDate { get; set; }

        public TaskExportDTO[] Tasks { get; set; }
    }

    [XmlType("Task")]
    public class TaskExportDTO
    {
        [XmlElement("Name")]
        public string Name { get; set; }
        [XmlElement("Label")]
        public string Label { get; set; }
    }
}
