using Restoran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restoran.ViewModels
{
    public class StavkaRacunaViewModel
    {
        public int stavkaId { get; set; }

        public int sifraRacuna { get; set; }
        public int kolicina { get; set; }
        public int proizvodId { get; set; }

        public  IEnumerable<Proizvod> proizvodiLista { get; set; }




    }
}