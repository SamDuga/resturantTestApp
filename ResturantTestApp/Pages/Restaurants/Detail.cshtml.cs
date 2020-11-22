using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RestaurantTestApp.Core;
using RestaurantTestApp.Data;

namespace ResturantTestApp.Pages.Restaurants
{
    public class DetailModel : PageModel
    {
        private readonly IRestaurantData restaurantData;

        public Restaurant Restaurant{ get; set; }

        [BindProperty(SupportsGet =true)]
        public int Id { get; set; }

        public DetailModel(IRestaurantData restaurantData)
        {
            this.restaurantData = restaurantData;
        }
        public IActionResult OnGet()
        {
            Restaurant = restaurantData.GetRestaurantById(Id);

            if (Restaurant == null) return RedirectToPage("/NotFound");

            return Page();
        }
    }
}