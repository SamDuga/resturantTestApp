using RestaurantTestApp.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using static RestaurantTestApp.Core.Restaurant;
using System.Security.Cryptography;
using System.ComponentModel.Design;

namespace RestaurantTestApp.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        readonly List<Restaurant> restaurants;

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

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            name = name?.ToLowerInvariant();

            return from r in restaurants
                   where string.IsNullOrEmpty(name) || r.Name.ToLowerInvariant().Contains(name)
                   orderby r.Name
                   select r;
        }
    }

}
