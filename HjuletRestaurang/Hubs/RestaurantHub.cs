using System;
using System.Collections.Generic;
using System.Linq;
using HjuletRestaurang.Data;
using HjuletRestaurang.Models;
using Microsoft.AspNet.SignalR;

namespace HjuletRestaurang.Hubs
{
    public class RestaurantHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public RestaurantHub()
        {
            _context = ApplicationDbContext.GetInstance;
        }

        public void OrderReady(string orderId)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == Guid.Parse(orderId));

            if (order != null)
            order.IsReady = true;

            Clients.All.orderReady(order);
        }
    }
}