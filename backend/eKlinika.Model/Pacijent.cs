
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Model
{
    public enum Spol
    {
        Musko,
        Zensko,
        Nepoznato
    }
    public class Pacijent
    {
     
        public int Id { get; set; }

        public string Ime { get; set; }
  
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
    
        public Spol Spol { get; set; }
        public string? Adresa { get; set; }
        public string? BrojTelefona { get; set; }
    }


}
