using Restoran.Models;
using Restoran.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Restoran.Controllers
{
    public class ProizvodController : Controller
    {
        RestoranContext _context = new RestoranContext();


        public int autoIncrement()
        {
            try
            {
                return (_context.Proizvods.Max(m => m.Id) + 1);
            }
            catch (Exception)
            {
                return 1;
            }
        }

        // GET: Proizvod
        public ActionResult Index()
        {
            IEnumerable<Proizvod> model = _context.Proizvods.OrderBy(m => m.TipProizvodaId).ToList();
            if (User.IsInRole(RoleName.MozeDaRadiSve))
                return View(model);

            else if (User.IsInRole(RoleName.DodajeRacunePorudzbineRezervacije))
                return View("IndexKonobar", model);

            else
                return View("IndexAnonymous",model);
        }

        // GET: Proizvod/Details/5
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije)]
        public ActionResult Details(int id)
        {
            Proizvod proizvod = _context.Proizvods.Find(id);
            ProizvodViewModel viewModel = new ProizvodViewModel
            {
                cena = proizvod.Cena,
                lager = proizvod.Lager,
                naziv = proizvod.Naziv,
                proizvodId = proizvod.Id,
                dobavljac = _context.Dobavljacs.Find(proizvod.DobavljacId),
                tipProizvod = _context.TipProizvods.Find(proizvod.TipProizvodaId)


            };
            return View(viewModel);
        }

        // GET: Proizvod/Create
        [Authorize(Roles = RoleName.MozeDaRadiSve)]
        public ActionResult Create()
        {
            List<Dobavljac> lista = _context.Dobavljacs.ToList();
            ProizvodViewModel viewModel = new ProizvodViewModel
            {
                tipoviProizvodaLista = _context.TipProizvods.ToList(),
                dobavljaciLista = _context.Dobavljacs.ToList()

            };


            return View(viewModel);
        }

        // POST: Proizvod/Create
        [HttpPost]
        [Authorize(Roles = RoleName.MozeDaRadiSve)]
        public ActionResult Create(FormCollection collection, ProizvodViewModel viewModel)
        {
            try
            {
                Proizvod proizvod = new Proizvod
                {
                    Cena = viewModel.cena,
                    Id = autoIncrement(), // dodaj auto increment u kodu
                    Lager = viewModel.lager,
                    Naziv = viewModel.naziv,
                    TipProizvodaId = viewModel.tipProizvodId,
                    DobavljacId = viewModel.dobavljacId

                };

                _context.Proizvods.Add(proizvod);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proizvod/Edit/5
        [Authorize(Roles = RoleName.MozeDaRadiSve)]
        public ActionResult Edit(int id)
        {

            return View(_context.Proizvods.Find(id));
        }

        // POST: Proizvod/Edit/5
        [HttpPost]
        [Authorize(Roles = RoleName.MozeDaRadiSve)]
        public ActionResult Edit(int id, FormCollection collection, Proizvod proizvod)
        {
            try
            {
                Proizvod proizvodZaEdit = _context.Proizvods.Find(id);

                proizvodZaEdit.Cena = proizvod.Cena;
                proizvodZaEdit.Naziv = proizvod.Naziv;

                _context.SaveChanges();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Proizvod/Delete/5
        [Authorize(Roles = RoleName.MozeDaRadiSve)]
        public ActionResult Delete(int id)
        {

            return View(_context.Proizvods.Find(id));
        }

        // POST: Proizvod/Delete/5
        [HttpPost]
        [Authorize(Roles = RoleName.MozeDaRadiSve)]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _context.Proizvods.Remove(_context.Proizvods.Find(id));
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
