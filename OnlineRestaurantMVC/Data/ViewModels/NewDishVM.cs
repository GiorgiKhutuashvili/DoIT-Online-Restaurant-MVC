using OnlineRestaurantMVC.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineRestaurantMVC.Data.ViewModels
{
    public class NewDishVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Select the category")]
        public DishCategory DishCategory { get; set; }
        public bool IsNutty { get; set; }
        public bool IsVegetarian { get; set; }
        [Required(ErrorMessage = "Select the Pepper Level")]
        public PepperLevel PepperLevel { get; set; }
        [Required(ErrorMessage = "Image URL is required")]
        public string ImageURL { get; set; }
    }
}
