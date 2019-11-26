using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Car")]
    public class CarImportDTO
    {
        [XmlElement("make")]
        public string Make { get; set; }

        [XmlElement("model")]
        public string Model { get; set; }

        [XmlElement("TraveledDistance")]
        public int TravelledDistance { get; set; }

        [XmlArray("parts")]
        public CarPartImportDTO[] Parts { get; set; }
    }

    [XmlType("partId")]
    public class CarPartImportDTO
    {
        [XmlAttribute("id")]
        public int PartId { get; set; }

        public int CarId { get; set; }
    }
}
