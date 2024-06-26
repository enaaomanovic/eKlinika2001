﻿using System;
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
  
        public int Id { get; set; }
       
        public string Ime { get; set; }
   
        public string Prezime { get; set; }
  
        public TitulaLjekara Titula { get; set; }
     
        public string Sifra { get; set; }

        public string? Username { get; set; }


    }

 
}
