using System;
using System.ComponentModel.DataAnnotations;

namespace eKlinika.Model
{
    public enum TitulaLjekara
    {
        Specijalista,
        Specijalizant,
        MedSestra
    }
    public class Ljekar
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public TitulaLjekara Titula { get; set; }
        [Required]
        public string Sifra { get; set; }

        public string? Username { get; set; }

        public byte[] LozinkaHash { get; set; }

        public byte[] LozinkaSalt { get; set; }
    }

 
}
