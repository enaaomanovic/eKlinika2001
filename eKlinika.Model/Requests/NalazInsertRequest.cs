using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Model.Requests
{
    public class NalazInsertRequest
    {
     
        public string TekstualniOpis { get; set; }
        public DateTime DatumIVrijemeKreiranja { get; set; }
    }

}
