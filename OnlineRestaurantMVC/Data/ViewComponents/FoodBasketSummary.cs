using OnlineRestaurantMVC.Data.Basket;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRestaurantMVC.Data.ViewComponents
{
    public class FoodBasketSummary : ViewComponent
    {
        private readonly FoodBasket _foodBasket;
        public FoodBasketSummary(FoodBasket foodBasket)
        {
            _foodBasket = foodBasket;
        }

        public IViewComponentResult Invoke()
        {
            var items = _foodBasket.GetFoodBasketItems();

            return View(items.Count);
        }
    }
}
