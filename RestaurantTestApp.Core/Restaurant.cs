using System;

namespace RestaurantTestApp.Core
{
    public class Restaurant
    {
        public enum CuisineType
        {
            None,
            Mexican,
            Italian,
            Indian,
            American
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}