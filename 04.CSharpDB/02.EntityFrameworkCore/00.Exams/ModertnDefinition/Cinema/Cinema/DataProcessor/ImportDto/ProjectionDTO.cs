using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Projection")]
    public class ProjectionDTO
    {
        [XmlElement("MovieId")]
        public int MovieId { get; set; }

        [XmlElement("HallId")]
        public int HallId { get; set; }

        [XmlIgnore]
        public DateTime DateTime { get; set; }

        [XmlElement("DateTime")]
        public string SomeDateString
        {
            get { return this.DateTime.ToString("yyyy-MM-dd HH:mm:ss"); }
            set { this.DateTime = DateTime.Parse(value); }
        }
        //<MovieId>38</MovieId>
        //<HallId>4</HallId>
        //<DateTime>2019-04-27 13:33:20</DateTime>
    }
}
