﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Model.Requests
{
    public class LjekarInsertRequest
    {
       
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public TitulaLjekara Titula { get; set; }
        public string Sifra { get; set; }
        public string Username { get; set; }

        public string Lozinka { get; set; }
    }
}
