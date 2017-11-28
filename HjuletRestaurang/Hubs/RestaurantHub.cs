using System;
using HjuletRestaurang.Data;
using Microsoft.AspNet.SignalR;

namespace HjuletRestaurang.Hubs
{
    public class RestaurantHub : Hub
    {
        private ApplicationDbContext _context;
        public RestaurantHub()
        {
            _context = ApplicationDbContext.GetInstance;
        }
        public void SendOrder(string message)
        {
            //todo split message, save to context, send to Kitchen Index
            //var guid = Guid.Parse(message);
            Clients.All.sendOrder(message);
        }
    }
}