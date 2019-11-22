using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Positions
{
    public class CreatePositionInputModel
    {
        [Required]
        [Display(Name = "Position Name")]
        public string PositionName { get; set; }
    }
}
