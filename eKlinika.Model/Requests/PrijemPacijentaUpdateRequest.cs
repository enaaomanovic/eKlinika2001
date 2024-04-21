using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Model.Requests
{
    public class PrijemPacijentaUpdateRequest
    {
        public DateTime DatumIVrijemePrijema { get; set; }

        public int? PacijentId { get; set; }
  

        public int? NadlezniLjekarId { get; set; }

        public bool HitniPrijem { get; set; }
    }
}
