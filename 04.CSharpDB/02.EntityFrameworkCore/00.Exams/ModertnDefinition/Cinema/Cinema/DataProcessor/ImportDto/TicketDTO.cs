using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Ticket")]
    public class TicketDTO
    {
        public int ProjectionId { get; set; }
        public decimal Price { get; set; }
    }
}