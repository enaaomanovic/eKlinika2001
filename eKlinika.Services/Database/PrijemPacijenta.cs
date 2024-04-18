using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Services.Database
{
    public class PrijemPacijenta
    {
        public int Id { get; set; }
        public DateTime DatumIVrijemePrijema { get; set; }
        public Pacijent Pacijent { get; set; }
        public Ljekar NadlezniLjekar { get; set; }
        public bool HitniPrijem { get; set; }
    }
}
