﻿using Microsoft.EntityFrameworkCore;
using OnlineRestaurantMVC.Models;

namespace OnlineRestaurantMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<FoodBasketItem> FoodBasketItems { get; set; }
    }
}
