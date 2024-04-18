using System;
using System.ComponentModel.DataAnnotations;

namespace eKlinika.Model
{
    public class Nalaz
    {
        public int Id { get; set; }
        [Required]
        public string TekstualniOpis { get; set; }
        [Required]
        public DateTime DatumIVrijemeKreiranja { get; set; }
    }
}
