using Microsoft.EntityFrameworkCore;
using OnlineRestaurantMVC.Models;

namespace OnlineRestaurantMVC.Data.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly AppDbContext _context;
        public OrdersService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId = null)
        {
            var orders = await _context.Orders
                .Include(order => order.OrderItems)
                .ThenInclude(orderItem => orderItem.Dish)
                .ToListAsync();

            return orders;
        }

        public async Task StoreOrderAsync(List<FoodBasketItem> items, string userId, string userEmailAddress)
        {
            var order = new Order()
            {
                UserId = userId,
                Email = userEmailAddress
            };

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            foreach (var item in items)
            {
                var orderItem = new OrderItem()
                {
                    Amount = item.Amount,
                    DishId = item.Dish.Id,
                    OrderId = order.Id,
                    Price = item.Dish.Price
                };
                await _context.OrderItems.AddAsync(orderItem);
            }
            await _context.SaveChangesAsync();
        }
    }
}
