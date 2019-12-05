using System.ComponentModel.DataAnnotations;

namespace SoftJail.Data.Models
{
    public class OfficerPrisoner
    {
        [Required]
        public int PrisonerId { get; set; }

        public Prisoner Prisoner { get; set; }

        [Required]
        public int OfficerId { get; set; }

        public Officer Officer { get; set; }
    }
}
