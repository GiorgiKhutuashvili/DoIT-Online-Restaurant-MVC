using OnlineRestaurantMVC.Data.Base;
using OnlineRestaurantMVC.Data.ViewModels;
using OnlineRestaurantMVC.Models;

namespace OnlineRestaurantMVC.Data.Services
{
    public interface IDishService
    {
        Task<IEnumerable<Dish>> GetAllDishesAsync();
        Task<Dish> GetDishByIdAsync(int id);
        Task AddDishAsync(NewDishVM dish);
        Task UpdateDishAsync(NewDishVM dish);
        Task DeleteDishAsync(int id);
        Task<bool> DishExistsAsync(int id);
    }
}
