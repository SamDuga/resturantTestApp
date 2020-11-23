using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantTestApp.Core;
using RestaurantTestApp.Data;

namespace RestaurantTestApp.Pages.Restaurants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        [BindProperty(SupportsGet = true)]
        public int Id { get; set; }
        [BindProperty]
        public Restaurant Restaurant { get; set; }
        public DeleteModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet()
        {
            Restaurant = restaurantData.GetRestaurantById(Id);

            if (Restaurant == null) return RedirectToPage("/NotFound");

            return Page();
        }

        public IActionResult OnPost()
        {
            var restaurant = restaurantData.DeleteRestaurant(Id);
            restaurantData.Commit();

            if (restaurant == null) return RedirectToPage("/NotFound");

            TempData["Message"] = $"{restaurant.Name} deleted sucessfully!";
            return RedirectToPage("./List");
        }
    }
}