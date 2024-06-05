using OnlineRestaurantMVC.Models;
using OnlineRestaurantMVC.Data.Base;

namespace OnlineRestaurantMVC.Data.Services
{
    public class DishService : IDishService
    {
        private readonly IDishRepository _dishRepository;
        public DishService(IDishRepository dishRepository)
        {
            _dishRepository = dishRepository;
        }

        public async Task<IEnumerable<Dish>> GetAllDishesAsync()
        {
            return await _dishRepository.GetAllAsync();
        }

        public async Task<Dish> GetDishByIdAsync(int id)
        {
            return await _dishRepository.GetByIdAsync(id);
        }
        public async Task AddDishAsync(Dish dish)
        {
            await _dishRepository.AddAsync(dish);
        }
        public async Task UpdateDishAsync(Dish dish)
        {
            await _dishRepository.UpdateAsync(dish);
        }
        public async Task DeleteDishAsync(int id)
        {
            await _dishRepository.DeleteAsync(id);
        }

        public async Task<bool> DishExistsAsync(int id)
        {
            return await _dishRepository.ExistsAsync(id);
        }
    }
}
