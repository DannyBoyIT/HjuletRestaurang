using System;
using HjuletRestaurang.Data;
using HjuletRestaurang.Models;
using Owin;

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
            var dish3 = new Dish { Id = Guid.NewGuid(), Name = "LyxKalops", Price = 189 };
            context.Dishes.Add(dish1);
            context.Dishes.Add(dish2);
            context.Dishes.Add(dish3);
        }
    }
}