using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HjuletRestaurang.Data;
using HjuletRestaurang.Hubs;
using HjuletRestaurang.Models;
using Microsoft.AspNet.SignalR;

namespace HjuletRestaurang.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = ApplicationDbContext.GetInstance;
        }

        public ActionResult Index()
        {
            return View(_context.Dishes);
        }

        [HttpPost]
        public ActionResult Index(List<Guid> dishIds)
        {
            var hubContext = GlobalHost.ConnectionManager.GetHubContext<RestaurantHub>();

            var order = new Order()
            {
                Id = Guid.NewGuid(),
                Dishes = new List<Dish>(),
                OrderNumber = _context.Orders.Count != 0 ? _context.Orders.OrderByDescending(o => o.OrderNumber).First().OrderNumber + 1 : 1
            };

            foreach (var guid in dishIds)
            {
                var dish = _context.Dishes.FirstOrDefault(d => d.Id == guid);

                if (dish != null)
                    order.Dishes.Add(dish);
            }

            _context.Orders.Add(order);

            hubContext.Clients.All.getOrder(order);

            return RedirectToAction("Orders", new {orderNumber = order.OrderNumber});
        }

        public ActionResult Orders(int? orderNumber)
        {
            ViewBag.OrderNumber = orderNumber.ToString();

            return View(_context.Orders.OrderByDescending(o=>o.OrderNumber).ToList());
        }
    }
}