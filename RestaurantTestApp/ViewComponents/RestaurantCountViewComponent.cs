using Microsoft.AspNetCore.Mvc;
using RestaurantTestApp.Data;

namespace RestaurantTestApp.ViewComponents
{
    public class RestaurantCountViewComponent : ViewComponent
    {
        private readonly IRestaurantData restaurantData;

        public RestaurantCountViewComponent(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restaurantData.RestaurantCount();
            return View(count);
        }
    }
}