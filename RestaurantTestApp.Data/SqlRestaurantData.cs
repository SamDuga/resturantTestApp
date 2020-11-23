using RestaurantTestApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RestaurantTestApp.Data
{
    public class SqlRestaurantData : IRestaurantData
    {
        private readonly RestaurantDbContext db;

        public SqlRestaurantData(RestaurantDbContext db)
        {
            this.db = db;
        }
        public int Commit()
        {
            return db.SaveChanges();
        }

        public Restaurant CreateRestaurant(Restaurant newRestaurant)
        {
            db.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant DeleteRestaurant(int id)
        {
            var restaurant = GetRestaurantById(id);
            if (restaurant != null) db.Remove(restaurant);

            return restaurant;
        }

        public IEnumerable<Restaurant> GetAllRestaurants()
        {
            var query = from r in db.Restaurants
                        orderby r.Name
                        select r;
            return query;
        }

        public Restaurant GetRestaurantById(int id)
        {
            return db.Restaurants.Find(id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name)
        {
            name = name?.ToLowerInvariant();

            var query = from r in db.Restaurants
                        where string.IsNullOrEmpty(name) || r.Name.ToLowerInvariant().Contains(name)
                        orderby r.Name
                        select r;

            return query;
        }

        public Restaurant UpdateRestaurant(Restaurant updatedRestaurant)
        {
            var entity = db.Restaurants.Attach(updatedRestaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedRestaurant;
        }

        public int RestaurantCount()
        {
            return db.Restaurants.Count();
        }
    }
}
