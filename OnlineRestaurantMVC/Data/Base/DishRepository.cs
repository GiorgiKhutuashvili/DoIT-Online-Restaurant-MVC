using Microsoft.EntityFrameworkCore;
using OnlineRestaurantMVC.Models;
using System.Linq.Expressions;

namespace OnlineRestaurantMVC.Data.Base
{
    public class DishRepository : IDishRepository
    {
        private readonly AppDbContext _context;
        public DishRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dish>> GetAllAsync()
        {
            var result = await _context.Set<Dish>().ToListAsync();
            return result;
        }
        public async Task<Dish> GetByIdAsync(int id)
        {
            var result = await _context.Set<Dish>().FindAsync(id);
            return result;
        }
        public async Task AddAsync(Dish dish)
        {
            await _context.Set<Dish>().AddAsync(dish);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Dish dish)
        {
            _context.Set<Dish>().Update(dish);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {
            var dish = await GetByIdAsync(id);
            _context.Set<Dish>().Remove(dish);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Set<Dish>().FindAsync(id) != null;
        }


        //public Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        //{
        //    throw new NotImplementedException();
        //}

        //public Task<T> GetByIdAsync(int id, params Expression<Func<T, object>>[] includeProperties)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
