using Restoran.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Restoran.ViewModels
{
    public class RezervacijaViewModel
    {
      
        public IEnumerable<Sto> stoloviLista { get; set; }
        public IEnumerable<Gost> gostiLista { get; set; }
        public DateTime datumVreme { get; set; }
        public int brojRezervacije { get; set; }

        public int sto { get; set; }
        public int gost { get; set; }

        public Gost gostPrikaz { get; set; }
        public Sto stoPrikaz { get; set; }


    }
}