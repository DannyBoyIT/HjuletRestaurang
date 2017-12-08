using System;
using HjuletRestaurang.Data;
using HjuletRestaurang.Models;
using Owin;
using System.Collections.Generic;

namespace HjuletRestaurang
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            Seed();
            app.MapSignalR();
        }

        private void Seed()
        {
            var context = ApplicationDbContext.GetInstance;
            var dish1 = new Dish { Id = Guid.NewGuid(), Name = "BUTTER CHICKEN", Price = 99 };
            var dish2 = new Dish { Id = Guid.NewGuid(), Name = "CHEESY BACON HAWAIIAN", Price = 139 };
            var dish3 = new Dish { Id = Guid.NewGuid(), Name = "GARDEN VEG", Price = 115 };
            var dish4 = new Dish { Id = Guid.NewGuid(), Name = "CHICKEN FAJITA", Price = 128 };
            var dish5 = new Dish { Id = Guid.NewGuid(), Name = "CHICKEN & CAMEMBERT", Price = 107 };
            var dish6 = new Dish { Id = Guid.NewGuid(), Name = "GRAND ITALIAN", Price = 95 };
            var dish7 = new Dish { Id = Guid.NewGuid(), Name = "FOUR CHEESE DELUXE", Price = 119 };
            context.Dishes.Add(dish1);
            context.Dishes.Add(dish2);
            context.Dishes.Add(dish3);
            context.Dishes.Add(dish4);
            context.Dishes.Add(dish5);
            context.Dishes.Add(dish6);
            context.Dishes.Add(dish7);

            var order1 = new Order { Id = Guid.NewGuid(), Dishes = new List<Dish>() { dish1 }, OrderNumber = 1, IsReady = true };
            var order2 = new Order { Id = Guid.NewGuid(), Dishes = new List<Dish>() { dish2, dish3 }, OrderNumber = 2};
            context.Orders.Add(order1);
            context.Orders.Add(order2);
        }
    }
}