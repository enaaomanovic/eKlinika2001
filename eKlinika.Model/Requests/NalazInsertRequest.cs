using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Model.Requests
{
    public class NalazInsertRequest
    {
     
        [Required]

        public string TekstualniOpis { get; set; }
        [Required]

        public DateTime DatumIVrijemeKreiranja { get; set; }
    }

}
