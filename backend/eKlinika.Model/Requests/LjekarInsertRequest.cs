using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Model.Requests
{
    public class LjekarInsertRequest
    {
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        public TitulaLjekara Titula { get; set; }
        [Required]
        public string Sifra { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Lozinka { get; set; }
    }
}
