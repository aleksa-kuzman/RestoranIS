using Restoran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restoran.Controllers
{
    public class GostController : Controller
    {
        RestoranContext _context = new RestoranContext();
        // GET: Gost
        public ActionResult Index()
        {
            return View(_context.Gosts.ToList());
        }

        // GET: Gost/Details/5
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Details(int id)
        {
            return View(_context.Gosts.SingleOrDefault(g => g.Id == id));
        }

        // GET: Gost/Create
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]

        public ActionResult Create()
        {
            return View();
        }

        // POST: Gost/Create
        [HttpPost]
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Create(FormCollection collection, Gost gost)
        {
            try
            {
                _context.Gosts.Add(gost);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Gost/Edit/5
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Edit(int id)
        {
            return View(_context.Gosts.SingleOrDefault(g => g.Id == id));


        }

        // POST: Gost/Edit/5
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection, Gost gost)
        {

            try
            {
                Gost gostZaEdit = _context.Gosts.Find(id);
                gostZaEdit.ImePrezime = gost.ImePrezime;
                _context.SaveChanges();

            }
            catch (Exception)
            {

                return View();
            }



            // TODO: Add update logic here


            return RedirectToAction("Index");


        }

        // GET: Gost/Delete/5
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Delete(int id)
        {
            return View(_context.Gosts.Find(id));
        }

        // POST: Gost/Delete/5
        [HttpPost]
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _context.Gosts.Remove(_context.Gosts.Find(id));
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
