﻿using System;
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

        //Gets checked dishes from the customers clientside and creates an order. Sends the order to the kitchen client side.
        public void SendOrder(string message)
        {
            var order = new Order();

            var dishGuids = message.Split(',');

            foreach (var guid in dishGuids)
            {
                var dish = _context.Dishes.FirstOrDefault(d => d.Id == Guid.Parse(guid));

                if (dish != null)
                    order.Dishes.Add(dish);
            }

            _context.Orders.Add(order);

            Clients.All.sendOrder(order);
        }
    }
}