using System.Collections.Generic;

namespace SoftUni.Models
{
    public class Town
    {
        public int TownId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}
