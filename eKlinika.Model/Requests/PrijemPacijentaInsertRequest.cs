using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Model.Requests
{
    public class PrijemPacijentaInsertRequest
    {
        public DateTime DatumIVrijemePrijema { get; set; }


        public int? PacijentId { get; set; }
        public int? NadlezniLjekarId { get; set; }
        public bool HitniPrijem { get; set; }
    }
}
