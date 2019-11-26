using System.Xml.Serialization;

namespace CarDealer.Dtos.Import
{
    [XmlType("Sale")]
    public class SaleImportDTO
    {
        [XmlElement("customerId")]
        public int CustomerId { get; set; }

        [XmlElement("carId")]
        public int CarId { get; set; }

        [XmlElement("discount")]
        public int Discount { get; set; }
    }
}
