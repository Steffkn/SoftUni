namespace P01_HospitalDatabase.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Medicament
    {
        public int MedicamentId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
