using OnlineRestaurantMVC.Models;
using OnlineRestaurantMVC.Data.Base;
using OnlineRestaurantMVC.Data.ViewModels;
using Microsoft.EntityFrameworkCore;
using OnlineRestaurantMVC.Data.Enums;
using System.Xml.Linq;

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
        public async Task AddDishAsync(NewDishVM dish)
        {
            var newDish = new Dish
            {
                Name = dish.Name,
                Description = dish.Description,
                Price = dish.Price,
                DishCategory = dish.DishCategory,
                IsNutty = dish.IsNutty,
                IsVegetarian = dish.IsVegetarian,
                PepperLevel = dish.PepperLevel,
                ImageURL = dish.ImageURL
            };
            await _dishRepository.AddAsync(newDish);
        }
        public async Task UpdateDishAsync(NewDishVM dish)
        {
            var dbDish = await _dishRepository.GetByIdAsync(dish.Id);

            if (dbDish != null)
            {
                dbDish.Name = dish.Name;
                dbDish.Description = dish.Description;
                dbDish.Price = dish.Price;
                dbDish.DishCategory = dish.DishCategory;
                dbDish.IsNutty = dish.IsNutty;
                dbDish.IsVegetarian = dish.IsVegetarian;
                dbDish.PepperLevel = dish.PepperLevel;
                dbDish.ImageURL = dish.ImageURL;
                await _dishRepository.UpdateAsync(dbDish);
            }
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
