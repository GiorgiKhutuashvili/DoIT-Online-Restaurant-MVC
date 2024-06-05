using OnlineRestaurantMVC.Models;
using System.Linq.Expressions;

namespace OnlineRestaurantMVC.Data.Base
{
    public interface IDishRepository
    {
        Task<IEnumerable<Dish>> GetAllAsync();
        Task<Dish> GetByIdAsync(int id);
        Task AddAsync(Dish dish);
        Task UpdateAsync(Dish dish);
        Task DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
