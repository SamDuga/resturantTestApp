using RestaurantTestApp.Core;
using System.Collections.Generic;

namespace RestaurantTestApp.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAllRestaurants();

        IEnumerable<Restaurant> GetRestaurantsByName(string name);

        Restaurant GetRestaurantById(int id);

        Restaurant UpdateRestaurant(Restaurant updatedRestaurant);

        Restaurant CreateRestaurant(Restaurant newRestaurant);

        Restaurant DeleteRestaurant(int id);

        int RestaurantCount();

        int Commit();
    }
}