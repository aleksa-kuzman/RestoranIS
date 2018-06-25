using Restoran.Models;
using Restoran.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restoran.Controllers
{
    public class RacunController : Controller
    {
        RestoranContext _context = new RestoranContext();
        Random rnd = new Random();

        public int vratiSifruRacuna(int brojStola)
        {
            return (brojStola + rnd.Next(1 , 365) + Convert.ToInt32(DateTime.Now.Minute) );
        }

        // GET: Racun
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Index()
        {
            
            return View(_context.Racuns.ToList());
        }

        // GET: Racun/Details/5
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije+", " +RoleName.MozeDaRadiSve)]
        public ActionResult Details(int id)
        {
            Racun racun = _context.Racuns.Find(id);
            RacunViewModel viewModel = new RacunViewModel
            {
                brojStola = racun.BrojStola,
                sifraRacuna = racun.SifraRacuna,
                stavkeRacunaLista = _context.StavkaRacunas.Where(m => m.SifraRacuna == id).ToList(),


            };
            return View(viewModel);
        }

        // GET: Racun/Create
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Create()
        {
            IEnumerable<int> stoloviSaRacunima = _context.Racuns.Select(m => m.BrojStola).ToList();
            IEnumerable<Sto> stolovi = _context.Stoes.ToList();
            List<Sto> stoloviKonacni = new List<Sto>();

            foreach (Sto s in stolovi)
            {
                if (!stoloviSaRacunima.Contains(s.BrojStola))
                    stoloviKonacni.Add(s);
            }
            RacunViewModel viewModel = new RacunViewModel
            {
                stoloviLista = stoloviKonacni
            };

            return View(viewModel);
        }

        // POST: Racun/Create
        [HttpPost]
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Create(FormCollection collection,RacunViewModel racunViewModel)
        {
            try
            {
                Racun racun = new Racun
                {
                    BrojStola = racunViewModel.brojStola,
                    SifraRacuna = vratiSifruRacuna(racunViewModel.brojStola)
                    
                };
                _context.Racuns.Add(racun);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                RacunViewModel viewModel = new RacunViewModel
                {
                    stoloviLista = _context.Stoes.ToList()
                };

                return View(viewModel);
               // return View();
            }
        }

        // GET: Racun/Edit/5


        // GET: Racun/Delete/5
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Delete(int id)
        {
          
            return View(_context.Racuns.Find(id));
        }

        // POST: Racun/Delete/5
        [HttpPost]
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _context.Racuns.Remove(_context.Racuns.Find(id));
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
