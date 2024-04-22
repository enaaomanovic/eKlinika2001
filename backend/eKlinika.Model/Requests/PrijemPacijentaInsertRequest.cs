using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Model.Requests
{
    public class PrijemPacijentaInsertRequest
    {
        [Required]
        public DateTime DatumIVrijemePrijema { get; set; }
        [Required]
        public int? PacijentId { get; set; }
        [Required]
        public int? NadlezniLjekarId { get; set; }
        [Required]

        public bool HitniPrijem { get; set; }
    }
}
