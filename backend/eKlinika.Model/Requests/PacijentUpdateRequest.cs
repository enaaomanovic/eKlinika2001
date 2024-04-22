using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Model.Requests
{
    public class PacijentUpdateRequest
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public Spol Spol { get; set; }
        public string? Adresa { get; set; }
        public string? BrojTelefona { get; set; }
    }
}
