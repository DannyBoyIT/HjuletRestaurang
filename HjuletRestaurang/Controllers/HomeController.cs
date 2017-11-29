using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HjuletRestaurang.Data;

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

        public ActionResult Orders()
        {

            return View(_context.Orders.OrderByDescending(o=>o.OrderNumber).ToList());
        }
    }
}