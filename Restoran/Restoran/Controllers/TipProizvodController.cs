using Restoran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restoran.Controllers
{
    public class TipProizvodController : Controller
    {
        RestoranContext _context = new RestoranContext();
        // GET: TipProizvod
        public ActionResult Index()
        {

            return View(_context.TipProizvods.ToList());
        }

        [Authorize(Roles = RoleName.MozeDaRadiSve)]
        public ActionResult ProizvodPoTipu(int id)
        {
            return View(_context.Proizvods.Where(m => m.TipProizvodaId == id).ToList());
        }

        // GET: TipProizvod/Details/5
        [Authorize(Roles = RoleName.MozeDaRadiSve) ]
        public ActionResult Details(int id)
        {
            return View(_context.Proizvods.SingleOrDefault(m=>m.Id == id));
        }

        //// GET: TipProizvod/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: TipProizvod/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TipProizvod/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: TipProizvod/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: TipProizvod/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: TipProizvod/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
