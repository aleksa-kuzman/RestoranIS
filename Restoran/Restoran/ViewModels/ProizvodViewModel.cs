using Restoran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restoran.ViewModels
{
    public class ProizvodViewModel
    {
        public int proizvodId { get; set; }
        public string naziv { get; set; }
        public int cena { get; set; }
        public int lager { get; set; }

        public int tipProizvodId{ get; set; }
        public int dobavljacId { get; set; }

        public IEnumerable<TipProizvod> tipoviProizvodaLista { get; set; }
        public IEnumerable<Dobavljac> dobavljaciLista { get; set; }

        public Dobavljac dobavljac { get; set; }
        public TipProizvod tipProizvod { get; set; }

    }
}