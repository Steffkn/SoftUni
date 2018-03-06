using System.ComponentModel.DataAnnotations;

namespace ProjectRider.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description  { get; set; }

        public long Budget { get; set; }
    }
}