using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HjuletRestaurang.Data;

namespace HjuletRestaurang.Controllers
{
    public class KitchenController : Controller
    {     
        public ActionResult Index()
        {
            return View();
        }
    }
}