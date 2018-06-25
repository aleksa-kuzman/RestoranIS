using Restoran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restoran.ViewModels
{
    public class RacunViewModel
    {
        public int sifraRacuna { get; set; }
        public int brojStola{ get; set; }

        public IEnumerable<Sto> stoloviLista { get; set; }
        public IEnumerable<StavkaRacuna> stavkeRacunaLista { get; set; }

    }
}