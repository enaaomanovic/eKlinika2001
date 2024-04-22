using System;
using System.ComponentModel.DataAnnotations;

namespace eKlinika.Model
{
    public class PrijemPacijenta
    {
   
        public int Id { get; set; }
       
        public DateTime DatumIVrijemePrijema { get; set; }

        public int? PacijentId { get; set; }
   
        public int? NadlezniLjekarId { get; set; }

        public bool? HitniPrijem { get; set; }


    }
}
