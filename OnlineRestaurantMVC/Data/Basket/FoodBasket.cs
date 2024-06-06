using OnlineRestaurantMVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRestaurantMVC.Data.Basket
{
    public class FoodBasket
    {
        public AppDbContext _context { get; set; }

        public string FoodBasketId { get; set; }
        public List<FoodBasketItem> FoodBasketItems { get; set; }
        public FoodBasket(AppDbContext context)
        {
            _context = context;
        }

        public static FoodBasket GetFoodBasket(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();

            string basketId = session.GetString("BasketId") ?? Guid.NewGuid().ToString();
            session.SetString("BasketId", basketId);

            return new FoodBasket(context) { FoodBasketId = basketId };
        }

        public void AddItemToBasket(Dish dish)
        {
            var foodBasketItem = _context.FoodBasketItems.FirstOrDefault(n => n.Dish.Id == dish.Id && n.FoodBasketId == FoodBasketId);

            if (foodBasketItem == null)
            {
                foodBasketItem = new FoodBasketItem()
                {
                    FoodBasketId = FoodBasketId,
                    Dish = dish,
                    Amount = 1
                };

                _context.FoodBasketItems.Add(foodBasketItem);
            }
            else
            {
                foodBasketItem.Amount++;
            }
            _context.SaveChanges();
        }

        public void RemoveItemFromBasket(Dish dish)
        {
            var foodBasketItem = _context.FoodBasketItems.FirstOrDefault(n => n.Dish.Id == dish.Id && n.FoodBasketId == FoodBasketId);

            if (foodBasketItem != null)
            {
                if (foodBasketItem.Amount > 1)
                {
                    foodBasketItem.Amount--;
                }
                else
                {
                    _context.FoodBasketItems.Remove(foodBasketItem);
                }
            }
            _context.SaveChanges();
        }

        public List<FoodBasketItem> GetFoodBasketItems()
        {
            return FoodBasketItems ?? (FoodBasketItems = _context.FoodBasketItems.Where(n => n.FoodBasketId == FoodBasketId).Include(n => n.Dish).ToList());
        }

        public double GetFoodBasketTotal() => _context.FoodBasketItems.Where(n => n.FoodBasketId == FoodBasketId).Select(n => n.Dish.Price * n.Amount).Sum();

        public async Task ClearFoodBasketAsync()
        {
            var items = await _context.FoodBasketItems.Where(n => n.FoodBasketId == FoodBasketId).ToListAsync();
            _context.FoodBasketItems.RemoveRange(items);
            await _context.SaveChangesAsync();
        }
    }
}
