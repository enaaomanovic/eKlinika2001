using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Services.Database
{
    public class Nalaz
    {
        public int Id { get; set; }
        public string TekstualniOpis { get; set; }
        public DateTime DatumIVrijemeKreiranja { get; set; }
    }
}
