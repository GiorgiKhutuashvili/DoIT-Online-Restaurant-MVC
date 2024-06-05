using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OnlineRestaurantMVC.Data;
using OnlineRestaurantMVC.Data.Services;

namespace OnlineRestaurantMVC.Controllers
{
    public class DishesController : Controller
    {
        private readonly IDishService _service;
        public DishesController(IDishService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allDishes = await _service.GetAllDishesAsync();
            return View(allDishes);
        }
        public async Task<IActionResult> Details(int id)
        {
            var dishDetails = await _service.GetDishByIdAsync(id);
            return View(dishDetails);
        }
        public IActionResult Create()
        {
            ViewData["Welcome"] = "Welcome to our restaurant";
            return View();
        }
    }
}
