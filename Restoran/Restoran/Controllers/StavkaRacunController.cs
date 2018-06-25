using Restoran.Models;
using Restoran.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Restoran.Controllers
{
    public class StavkaRacunController : Controller
    {
        RestoranContext _context = new RestoranContext();

        public bool saljiMailDobavljacu(int dobavljacId,int proizvodId,int kolicina)
        {
            try
            {
                Proizvod proizvod = _context.Proizvods.Find(proizvodId);
                Dobavljac dobavljac = _context.Dobavljacs.Find(dobavljacId);
                SmtpClient client = new SmtpClient();
                MailMessage mailMessage = new MailMessage();

                mailMessage.From = new MailAddress("aleksa.kuzman.996@gmail.com");
                mailMessage.To.Add(dobavljac.Email);
                mailMessage.Subject = "Porucivanje proizvoda: " + proizvod.Naziv;
                mailMessage.Body = "Poštovani, \n\rŽelimo da naručimo " + kolicina + " komada  Vašeg proizvoda: " + proizvod.Naziv + "\n\rS poštovanjem Vaš kupac";

                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                
                throw;
               // return false;
            }
           
        }

        public int autoIncrement ()
        {
            try
            {
                return (_context.StavkaRacunas.Max(m => m.StavkaId) +1);

            }
            catch (Exception)
            {
                return 1;           
            }

        }
        // GET: StavkaRacun
        public ActionResult Index()
        {
            return View();
        }

        // GET: StavkaRacun/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: StavkaRacun/Create
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]

        public ActionResult Create(int sifraRacuna)
        {
            StavkaRacunaViewModel viewModel = new StavkaRacunaViewModel
            {
                proizvodiLista = _context.Proizvods.ToList(),
                sifraRacuna = sifraRacuna

            };
            return View(viewModel);
        }

        // POST: StavkaRacun/Create
        [HttpPost]
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]

        public ActionResult Create(FormCollection collection,StavkaRacunaViewModel viewModel)
        {
            try
            {
                StavkaRacuna stavkaRacuna = new StavkaRacuna
                {
                    ProizvodId = viewModel.proizvodId,
                    Kolicina = viewModel.kolicina,
                    SifraRacuna = viewModel.sifraRacuna,
                    StavkaId = autoIncrement() 
                };

                _context.StavkaRacunas.Add(stavkaRacuna);
                _context.SaveChanges();

                var proizvod = _context.Proizvods.Find(viewModel.proizvodId);
                proizvod.Lager -= viewModel.kolicina;
                if(proizvod.Lager < 10)
                {
                    saljiMailDobavljacu(proizvod.DobavljacId, proizvod.Id, 100);
                }
                _context.SaveChanges();

                return RedirectToAction("Index","Racun");
            }
            catch
            {
                return View();
            }
        }

        // GET: StavkaRacun/Edit/5
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]

        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StavkaRacun/Edit/5
        [HttpPost]
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]

        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: StavkaRacun/Delete/5
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]

        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StavkaRacun/Delete/5
        [HttpPost]
        [Authorize(Roles = RoleName.DodajeRacunePorudzbineRezervacije + ", " + RoleName.MozeDaRadiSve)]

        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
