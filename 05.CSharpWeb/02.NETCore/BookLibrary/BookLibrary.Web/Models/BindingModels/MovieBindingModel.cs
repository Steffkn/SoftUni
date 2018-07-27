using System.ComponentModel.DataAnnotations;

namespace BookLibrary.Web.Models.BindingModels
{
    public class MovieBindingModel
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        [Display(Name = "Producer")]
        public string ProducerName { get; set; }

        [Required]
        [Display(Name = "Youtube trailer")]
        public string YoutubeTrailerId { get; set; }
    }
}
