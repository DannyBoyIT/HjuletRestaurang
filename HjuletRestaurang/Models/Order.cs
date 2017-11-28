using System;
using System.Collections.Generic;

namespace HjuletRestaurang.Models
{
    public class Order
    {
        public Guid Id { get; set; }
        public List<Dish> Dishes { get; set; }
        public int OrderNumber { get; set; }
    }
}