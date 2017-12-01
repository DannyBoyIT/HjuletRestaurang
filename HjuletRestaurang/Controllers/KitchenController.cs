using System.Linq;
using System.Web.Mvc;
using HjuletRestaurang.Data;

namespace HjuletRestaurang.Controllers
{
    public class KitchenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitchenController()
        {
            _context = ApplicationDbContext.GetInstance;
        }

        public ActionResult Index()
        {
            return View(_context.Orders.Where(o => !o.IsReady).ToList());
        }
    }
}