namespace P01_HospitalDatabase.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Visitation
    {
        public int VisitationId { get; set; }

        [MaxLength(250)]
        [Required]
        public string Comments { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public int PatientId { get; set; }

        public Patient Patient { get; set; }

        [Required]
        public int DoctorId { get; set; }

        public Doctor Doctor { get; set; }
    }
}
