using Microsoft.EntityFrameworkCore;
using RestaurantTestApp.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantTestApp.Data
{
    public class RestaurantDbContext : DbContext
    {
        public RestaurantDbContext(DbContextOptions<RestaurantDbContext> options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
