using System;
using System.ComponentModel.DataAnnotations;

namespace eKlinika.Model
{
    public class Nalaz
    {
      
        public int Id { get; set; }
     
        public string TekstualniOpis { get; set; }
        public int? PrijemPacijentaId { get; set; }

     

        public DateTime DatumIVrijemeKreiranja { get; set; }
    }
}
