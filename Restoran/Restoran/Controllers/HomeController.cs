using Restoran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restoran.Controllers
{
    public class HomeController : Controller
    {
        RestoranContext _context = new RestoranContext();

        public ActionResult Index()
        { 
          return View(_context.Proizvods.OrderBy(m=>m.TipProizvodaId).ToList() );
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}