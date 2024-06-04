using Microsoft.EntityFrameworkCore;
using OnlineRestaurantMVC.Models;

namespace OnlineRestaurantMVC.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Dish> Dishes { get; set; }
    }
}
