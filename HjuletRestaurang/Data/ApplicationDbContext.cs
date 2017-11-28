using System.Collections.Generic;
using System.Data.Entity;
using HjuletRestaurang.Models;

namespace HjuletRestaurang.Data
{
    public sealed class ApplicationDbContext
    {
        private static readonly ApplicationDbContext Instance = new ApplicationDbContext();

        public List<Dish> Dishes { get; set; } = new List<Dish>();
        public List<Order> Orders { get; set; } = new List<Order>();

        private ApplicationDbContext() { }

        public static ApplicationDbContext GetInstance
        {
            get
            {
                return Instance;
            }
        }
    }
}