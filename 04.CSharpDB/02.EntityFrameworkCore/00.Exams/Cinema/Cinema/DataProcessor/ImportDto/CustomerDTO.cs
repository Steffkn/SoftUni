using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Cinema.DataProcessor.ImportDto
{
    [XmlType("Customer")]
    public class CustomerDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Age { get; set; }
        public decimal Balance { get; set; }
        public TicketDTO[] Tickets { get; set; }
        //    <Customer>
        //<FirstName>Randi</FirstName>
        //<LastName>Ferraraccio</LastName>
        //<Age>20</Age>
        //<Balance>59.44</Balance>
        //<Tickets>

    }
}
