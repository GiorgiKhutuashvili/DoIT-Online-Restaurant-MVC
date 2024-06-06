using System.ComponentModel.DataAnnotations;

namespace OnlineRestaurantMVC.Models
{
    public class FoodBasketItem
    {
        [Key]
        public int Id { get; set; }

        public Dish Dish { get; set; }
        public int Amount { get; set; }


        public string FoodBasketId { get; set; }
    }
}
