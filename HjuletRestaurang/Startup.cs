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
            var dish1 = new Dish {Id = Guid.NewGuid(), Name = "Pasta Contono", Price = 89};
            var dish2 = new Dish { Id = Guid.NewGuid(), Name = "Fläskkorv med mos", Price = 59 };
            var dish3 = new Dish { Id = Guid.NewGuid(), Name = "Lyxkalops", Price = 189 };
            context.Dishes.Add(dish1);
            context.Dishes.Add(dish2);
            context.Dishes.Add(dish3);


            var order1 = new Order { Id = Guid.NewGuid(), Dishes = new List<Dish>() { dish1 }, OrderNumber = 1, IsReady=true };
            var order2 = new Order { Id = Guid.NewGuid(), Dishes = new List<Dish>() { dish2,dish3}, OrderNumber = 2 };
            context.Orders.Add(order1);
            context.Orders.Add(order2);
        }
    }
}