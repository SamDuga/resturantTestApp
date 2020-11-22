using System.ComponentModel.DataAnnotations;

namespace RestaurantTestApp.Core
{
    public enum CuisineType
    {
        None,
        Mexican,
        Italian,
        Indian,
        American
    }

    public class Restaurant
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public CuisineType Cuisine { get; set; }
    }
}