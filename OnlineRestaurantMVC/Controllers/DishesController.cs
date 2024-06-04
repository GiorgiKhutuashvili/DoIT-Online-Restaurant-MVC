using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineRestaurantMVC.Data;

namespace OnlineRestaurantMVC.Controllers
{
    public class DishesController : Controller
    {
        private readonly AppDbContext _context;
        public DishesController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allDishes = await _context.Dishes.ToListAsync();
            return View(allDishes);
        }
    }
}
