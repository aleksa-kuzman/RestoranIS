using Restoran.Models;
using Restoran.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restoran.Controllers
{
    public class RezervacijaController : Controller
    {
        RestoranContext _context = new RestoranContext();
        Random rnd = new Random();

        public int vratiBrojRezervacije (int gostId,int stoId)
        {
            
            int brojRezervacije = gostId + stoId + rnd.Next(1, 365);

            return brojRezervacije;
        }

        // GET: Rezervacija
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Index()
        {
            
            return View(_context.Rezervacijas.ToList());
        }

        // GET: Rezervacija/Details/5
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Details(int id)
        {
            RezervacijaViewModel viewModel = new RezervacijaViewModel();
            Rezervacija rezervacija = _context.Rezervacijas.Where(m=>m.BrojRezervacije == id).SingleOrDefault();
            //Mapiranje
            viewModel.gostPrikaz = _context.Gosts.Where(m => m.Id == rezervacija.GostId ).SingleOrDefault();
            viewModel.stoPrikaz = _context.Stoes.Where(m => m.BrojStola == rezervacija.BrojStola).SingleOrDefault();
            viewModel.brojRezervacije = rezervacija.BrojRezervacije;

     
            return View(viewModel);
        }

        // GET: Rezervacija/Create
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Create()
        {
            RezervacijaViewModel viewModel = new RezervacijaViewModel();
            IEnumerable<int> rezervacije = _context.Rezervacijas.Select(m=>m.BrojStola).ToList();

            List<Sto> stoloviPrihvaceni = new List<Sto>();           
            var stolovi = _context.Stoes.ToList();
            

            foreach( Sto s in stolovi)
            {
                if(!rezervacije.Contains(s.BrojStola))
                {
                    stoloviPrihvaceni.Add(s);
                }
            }


            viewModel.stoloviLista = stoloviPrihvaceni;
            viewModel.gostiLista = _context.Gosts.ToList();
            viewModel.datumVreme = SqlDateTime.MinValue.Value;


            return View(viewModel);
        }

        // POST: Rezervacija/Create
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        [HttpPost]
        public ActionResult Create(FormCollection collection,RezervacijaViewModel rezervacijaViewModel)
        {
           
                Rezervacija rezervacija = new Rezervacija
                {
                    BrojRezervacije = vratiBrojRezervacije(rezervacijaViewModel.gost,rezervacijaViewModel.sto),
                    BrojStola = rezervacijaViewModel.sto,
                    GostId = rezervacijaViewModel.gost,
                    DatumVreme = rezervacijaViewModel.datumVreme,
                   
                };

                _context.Rezervacijas.Add(rezervacija);
                _context.SaveChanges();


                return RedirectToAction("Index");
            
            //catch(Exception ex)
            //{
            //    RezervacijaViewModel viewModel = new RezervacijaViewModel();

            //    viewModel.stoloviLista = _context.Stoes.ToList();
            //    viewModel.gostiLista = _context.Gosts.ToList();
            //    return View(viewModel);
            //}
        }



        // GET: Rezervacija/Delete/5
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Delete(int id)
        {
            Rezervacija rezervacija = _context.Rezervacijas.SingleOrDefault(c => c.BrojRezervacije == id);

            RezervacijaViewModel viewModel = new RezervacijaViewModel
            {
                brojRezervacije = rezervacija.BrojRezervacije,
                gost = rezervacija.GostId,
                sto = rezervacija.BrojStola,
                datumVreme = rezervacija.DatumVreme,
                stoPrikaz = _context.Stoes.SingleOrDefault(m => m.BrojStola == rezervacija.BrojStola),
                gostPrikaz = _context.Gosts.SingleOrDefault(m => m.Id == rezervacija.GostId)



            };

            return View(viewModel);
        }

        // POST: Rezervacija/Delete/5
        [HttpPost]
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _context.Rezervacijas.Remove(_context.Rezervacijas.SingleOrDefault(m => m.BrojRezervacije == id));
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
