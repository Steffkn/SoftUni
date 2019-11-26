using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Supplier")]
    public class SupplierImportDTO
    {
        [XmlElement("name")]
        public string Name { get; set; }

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }
    }
}
