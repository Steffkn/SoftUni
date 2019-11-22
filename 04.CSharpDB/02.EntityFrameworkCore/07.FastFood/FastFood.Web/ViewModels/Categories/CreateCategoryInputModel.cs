using System.ComponentModel.DataAnnotations;

namespace FastFood.Web.ViewModels.Categories
{
    public class CreateCategoryInputModel
    {
        [Required]
        [Display(Name = "Category name")]
        [StringLength(30, MinimumLength = 3)]
        public string CategoryName { get; set; }
    }
}
