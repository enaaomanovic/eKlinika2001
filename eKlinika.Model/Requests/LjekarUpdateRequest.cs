using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Model.Requests
{
    public class LjekarUpdateRequest
    {
      
        public string Ime { get; set; }

        public string Prezime { get; set; }
        public TitulaLjekara Titula { get; set; }
        public string Sifra { get; set; }
    }
}
