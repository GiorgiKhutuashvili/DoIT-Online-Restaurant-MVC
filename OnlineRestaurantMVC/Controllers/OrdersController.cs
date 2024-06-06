using OnlineRestaurantMVC.Data.Basket;
using OnlineRestaurantMVC.Data.Services;
using OnlineRestaurantMVC.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OnlineRestaurantMVC.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IDishService _dishService;
        private readonly FoodBasket _foodBasket;
        private readonly IOrdersService _ordersService;

        public OrdersController(IDishService dishService, FoodBasket foodBasket, IOrdersService ordersService)
        {
            _dishService = dishService;
            _foodBasket = foodBasket;
            _ordersService = ordersService;
        }

        public async Task<IActionResult> Index()
        {
            var items = _foodBasket.GetFoodBasketItems();
            _foodBasket.FoodBasketItems = items;
            var response = new FoodBasketVM()
            {
                FoodBasket = _foodBasket,
                FoodBasketTotal = _foodBasket.GetFoodBasketTotal()
            };

            return View(response);
        }
        public IActionResult FoodBasket()
        {
            var items = _foodBasket.GetFoodBasketItems();
            _foodBasket.FoodBasketItems = items;

            var response = new FoodBasketVM()
            {
                FoodBasket = _foodBasket,
                FoodBasketTotal = _foodBasket.GetFoodBasketTotal()
            };

            return View(response);
        }

        public async Task<IActionResult> AddItemToFoodBasket(int id)
        {
            var item = await _dishService.GetDishByIdAsync(id);

            if (item != null)
            {
                _foodBasket.AddItemToBasket(item);
            }
            return RedirectToAction(nameof(FoodBasket));
        }

        public async Task<IActionResult> RemoveItemFromFoodBasket(int id)
        {
            var item = await _dishService.GetDishByIdAsync(id);

            if (item != null)
            {
                _foodBasket.RemoveItemFromBasket(item);
            }
            return RedirectToAction(nameof(FoodBasket));
        }

        public async Task<IActionResult> CompleteOrder()
        {
            var items = _foodBasket.GetFoodBasketItems();
            string userId = "";
            string userEmailAddress = "";

            await _ordersService.StoreOrderAsync(items, userId, userEmailAddress);
            await _foodBasket.ClearFoodBasketAsync();

            return View("OrderCompleted");
        }
    }
}
