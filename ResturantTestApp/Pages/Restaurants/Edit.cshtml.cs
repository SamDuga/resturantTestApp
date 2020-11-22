using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using RestaurantTestApp.Core;
using RestaurantTestApp.Data;
using System.Collections.Generic;

namespace ResturantTestApp.Pages.Restaurants
{
    public class EditModel : PageModel
    {
        private readonly IRestaurantData restaurantData;
        private readonly IHtmlHelper htmlHelper;

        [BindProperty(SupportsGet =true)]
        public int? Id { get; set; }
        [BindProperty]
        public Restaurant Restaurant { get; set; }

        public IEnumerable<SelectListItem> Cuisines { get; set; }

        public EditModel(IRestaurantData restaurantData, IHtmlHelper htmlHelper)
        {
            this.restaurantData = restaurantData;
            this.htmlHelper = htmlHelper;
        }

        public IActionResult OnGet()
        {
            if (Id.HasValue)
            {
                Restaurant = restaurantData.GetRestaurantById(Id.Value);
            }
            else Restaurant = new Restaurant();

            Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();            

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                Cuisines = htmlHelper.GetEnumSelectList<CuisineType>();
                return Page();
            }

            if (Restaurant.Id > 0)
            {
                restaurantData.UpdateRestaurant(Restaurant);
                TempData["Message"] = "Restaurant updated sucessfully!";
            }
            else
            {
                restaurantData.CreateRestaurant(Restaurant);
                TempData["Message"] = "Restaurant created sucessfully!";
            }

            restaurantData.Commit();            
            return RedirectToPage("./Detail", new { Id });
        }
    }
}