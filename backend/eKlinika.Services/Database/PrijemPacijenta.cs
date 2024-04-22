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
        public int? PacijentId { get; set; }
        public virtual  Pacijent? Pacijent { get; set; }
        public int? NadlezniLjekarId { get; set; }

        public virtual Ljekar? NadlezniLjekar { get; set; }
        public bool? HitniPrijem { get; set; }
    }
}
