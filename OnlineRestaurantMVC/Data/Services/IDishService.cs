using OnlineRestaurantMVC.Data.Base;
using OnlineRestaurantMVC.Models;

namespace OnlineRestaurantMVC.Data.Services
{
    public interface IDishService
    {
        Task<IEnumerable<Dish>> GetAllDishesAsync();
        Task<Dish> GetDishByIdAsync(int id);
        Task AddDishAsync(Dish dish);
        Task UpdateDishAsync(Dish dish);
        Task DeleteDishAsync(int id);
        Task<bool> DishExistsAsync(int id);
    }
}
