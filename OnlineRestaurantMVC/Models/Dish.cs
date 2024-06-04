using OnlineRestaurantMVC.Data.Enums;
using System.ComponentModel.DataAnnotations;

namespace OnlineRestaurantMVC.Models
{
    public class Dish
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public DishCategory DishCategory { get; set; }
        public bool IsNutty { get; set; }
        public bool IsVegetarian { get; set; }
        public PepperLevel PepperLevel { get; set; }
        public string ImageURL { get; set; }

    }
}
