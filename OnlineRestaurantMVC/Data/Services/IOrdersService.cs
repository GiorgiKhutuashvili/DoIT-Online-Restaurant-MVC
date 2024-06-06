using OnlineRestaurantMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRestaurantMVC.Data.Services
{
    public interface IOrdersService
    {
        Task StoreOrderAsync(List<FoodBasketItem> items, string userId, string userEmailAddress);
        Task<List<Order>> GetOrdersByUserIdAndRoleAsync(string userId);
    }
}
