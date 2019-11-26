using System.Xml.Serialization;

namespace CarDealer.Dtos.Export
{
    [XmlType("car")]
    public class CarPartsExportDTO
    {
        [XmlAttribute("make")]
        public string Make { get; set; }

        [XmlAttribute("model")]
        public string Model { get; set; }

        [XmlAttribute("travelled-distance")]
        public long TravelledDistance { get; set; }

        [XmlArray("parts")]
        public PartExportDTO[] Parts { get; set; }
    }

    [XmlType("part")]
    public class PartExportDTO
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("price")]
        public decimal Price { get; set; }
    }
}
