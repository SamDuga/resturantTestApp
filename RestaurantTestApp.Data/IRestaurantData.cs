using RestaurantTestApp.Core;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantTestApp.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();

        IEnumerable<Restaurant> GetRestaurantsByName(string name);

        Restaurant GetRestaurantById(int id);

        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);
        Restaurant CreateRestaurant(Restaurant newRestaurant);

        int Commit();
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant {Id = 1, Name = "Sam's Pizza Wagon", Location = "Wisconsin", Cuisine = CuisineType.Italian},
                new Restaurant {Id = 2, Name = "Cinnabongo", Location = "London", Cuisine = CuisineType.Mexican},
                new Restaurant {Id = 3, Name = "Saffron Palace", Location = "New York", Cuisine = CuisineType.Indian}
            };
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            return from r in restaurants
                   orderby r.Name
                   select r;
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            name = name?.ToLowerInvariant();

            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.ToLowerInvariant().Contains(name)
                   orderby r.Name
                   select r;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var restaurant = restaurants.SingleOrDefault(r => r.Id == updatedRestaurant.Id);

            if (restaurant != null)
            {
                restaurant.Name = updatedRestaurant.Name;
                restaurant.Location = updatedRestaurant.Location;
                restaurant.Cuisine = updatedRestaurant.Cuisine;
            }

            return restaurant;
        }

        public Restaurant CreateRestaurant(Restaurant newRestaurant)
        {
            newRestaurant.Id = restaurants.Max(r => r.Id) + 1;

            restaurants.Add(newRestaurant);

            return newRestaurant;
        }

        public int Commit()
        {
            return 0;
        }
    }
}