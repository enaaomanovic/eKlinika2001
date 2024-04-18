using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Services.Database
{
    public enum TitulaLjekara
    {
        Specijalista,
        Specijalizant,
        MedSestra
    }
    public class Ljekar
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public TitulaLjekara Titula { get; set; }
        public string Sifra { get; set; }

        public string? Username { get; set; }

        public byte[] LozinkaHash { get; set; }

        public byte[] LozinkaSalt { get; set; }
    }
}
