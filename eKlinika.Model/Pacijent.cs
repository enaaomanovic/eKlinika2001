
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
        [Key]
        public int Id { get; set; }

        [Required]
        public string Ime { get; set; }

        [Required]
        public string Prezime { get; set; }

        [Required]
        public DateTime DatumRodjenja { get; set; }
        [Required]
        public Spol Spol { get; set; }
        public string? Adresa { get; set; }
        public string? BrojTelefona { get; set; }
    }


}
