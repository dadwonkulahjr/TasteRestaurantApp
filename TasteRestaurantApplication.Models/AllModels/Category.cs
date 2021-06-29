using System.ComponentModel.DataAnnotations;

namespace TasteRestaurantApplication.Models.AllModels
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Display(Name ="Category Name"), Required]
        public string Name { get; set; }
        [Display(Name = "Display Order"), Required]
        public int DisplayOrder { get; set; }
    }
}
