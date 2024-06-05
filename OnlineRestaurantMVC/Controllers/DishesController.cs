using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OnlineRestaurantMVC.Data;
using OnlineRestaurantMVC.Data.Services;
using OnlineRestaurantMVC.Data.ViewModels;

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
        public async Task<IActionResult> Filter(string searchString)
        {
            var allDishes = await _service.GetAllDishesAsync();

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allDishes.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();
                return View("Index", filteredResult);
            }

            return View("Index", allDishes);
        }
        public async Task<IActionResult> Details(int id)
        {
            var dishDetails = await _service.GetDishByIdAsync(id);
            if (dishDetails == null)
            {
                return NotFound();
            }
            return View(dishDetails);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewDishVM viewModel)
        {
            if (ModelState.IsValid)
            {
                await _service.AddDishAsync(viewModel);
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var dishDetails = await _service.GetDishByIdAsync(id);
            if (dishDetails == null) return View("NotFound");

            var response = new NewDishVM()
            {
                Id = dishDetails.Id,
                Name = dishDetails.Name,
                Description = dishDetails.Description,
                Price = dishDetails.Price,
                IsNutty = dishDetails.IsNutty,
                IsVegetarian = dishDetails.IsVegetarian,
                ImageURL = dishDetails.ImageURL,
                DishCategory = dishDetails.DishCategory,
                PepperLevel = dishDetails.PepperLevel,
            };

            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewDishVM dish)
        {
            if (id != dish.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                return View(dish);
            }

            await _service.UpdateDishAsync(dish);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int id)
        {
            var dish = await _service.GetDishByIdAsync(id);
            if (dish == null)
            {
                return NotFound();
            }
            return View(dish);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteDishAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
