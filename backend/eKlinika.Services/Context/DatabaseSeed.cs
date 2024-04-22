using eKlinika.Services.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.Services.Context
{
    public partial class eKlinikaContext
    {
        private readonly DateTime _dateTime = new(2023, 2, 1, 0, 0, 0, 0, DateTimeKind.Local);


        public void SeedData(ModelBuilder modelBuilder)
        {
            SeedPacijenti(modelBuilder);
            SeedLjekari(modelBuilder);
            SeedPrijemPacijenta(modelBuilder);
            SeedNalaz(modelBuilder);

        }

        private void SeedPacijenti(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacijent>().HasData(
                new Pacijent()
                {
                    Id = 2,
                    Ime = "John",
                    Prezime = "Doe",
                    DatumRodjenja = new DateTime(1990, 5, 15),
                    Spol = Spol.Musko, 
                    Adresa = "123 Elm Street",
                    BrojTelefona = "062123456"
                },
                new Pacijent()
                {
                    Id = 3,
                    Ime = "Jane",
                    Prezime = "Smith",
                    DatumRodjenja = new DateTime(1985, 10, 2),
                    Spol = Spol.Zensko,
                    Adresa = "456 Oak Avenue",
                    BrojTelefona = "063987654"
                },
                new Pacijent()
                {
                    Id = 4,
                    Ime = "Michael",
                    Prezime = "Johnson",
                    DatumRodjenja = new DateTime(1978, 12, 18),
                    Spol = Spol.Musko,
                    Adresa = "789 Maple Road",
                    BrojTelefona = "064654321"
                },
                new Pacijent()
                {
                    Id = 5,
                    Ime = "Emily",
                    Prezime = "Davis",
                    DatumRodjenja = new DateTime(1983, 3, 8),
                    Spol = Spol.Zensko,
                    Adresa = "567 Pine Avenue",
                    BrojTelefona = "065987654"
                },
                new Pacijent()
                {
                    Id = 6,
                    Ime = "Daniel",
                    Prezime = "Brown",
                    DatumRodjenja = new DateTime(1995, 8, 21),
                    Spol = Spol.Musko,
                    Adresa = "234 Cedar Lane",
                    BrojTelefona = "066123987"
                },
                new Pacijent()
                {
                    Id = 7,
                    Ime = "Sophia",
                    Prezime = "Miller",
                    DatumRodjenja = new DateTime(1972, 6, 30),
                    Spol = Spol.Zensko,
                    Adresa = "890 Birch Street",
                    BrojTelefona = "067456123"
                },
                new Pacijent()
                {
                    Id = 8,
                    Ime = "David",
                    Prezime = "Wilson",
                    DatumRodjenja = new DateTime(1980, 9, 12),
                    Spol = Spol.Musko,
                    Adresa = "345 Oak Lane",
                    BrojTelefona = "068321654"
                },
                new Pacijent()
                {
                    Id = 9,
                    Ime = "Olivia",
                    Prezime = "Taylor",
                    DatumRodjenja = new DateTime(1992, 11, 5),
                    Spol = Spol.Zensko,
                    Adresa = "678 Elm Avenue",
                    BrojTelefona = "069987654"
                }
            );
        }

        private void SeedLjekari(ModelBuilder modelBuilder)
        {

            var hash = new byte[] { 205, 173, 238, 240, 123, 28, 44, 53, 56, 164, 63, 104, 173, 124, 252, 68, 180, 14, 228, 115 };
            var salt = new byte[] { 0, 15, 217, 112, 57, 244, 61, 193, 39, 247, 215, 237, 250, 28, 45, 120 };
            modelBuilder.Entity<Ljekar>().HasData(
           new Ljekar()
           {
               Id = 2,
               Ime = "John",
               Prezime = "Smith",
               Titula = TitulaLjekara.Specijalista,
               Sifra = "JS123",
               Username = "john",
               LozinkaHash = hash,
               LozinkaSalt = salt
           },
           new Ljekar()
           {
               Id = 3,
               Ime = "Emily",
               Prezime = "Davis",
               Titula = TitulaLjekara.MedSestra,
               Sifra = "ED456",
               Username = "emily",
               LozinkaHash = hash,
               LozinkaSalt = salt
           },
           new Ljekar()
           {
               Id = 4,
               Ime = "Michael",
               Prezime = "Johnson",
               Titula = TitulaLjekara.Specijalista,
               Sifra = "MJ789",
               Username = "michael",
               LozinkaHash = hash,
               LozinkaSalt = salt
           },
           new Ljekar()
           {
               Id = 5,
               Ime = "Sophia",
               Prezime = "Miller",
               Titula = TitulaLjekara.Specijalizant,
               Sifra = "SM234",
               Username = "sophia",
               LozinkaHash = hash,
               LozinkaSalt = salt
           },
           new Ljekar()
           {
               Id = 6,
               Ime = "Daniel",
               Prezime = "Brown",
               Titula = TitulaLjekara.Specijalista,
               Sifra = "DB567",
               Username = "daniel",
               LozinkaHash = hash,
               LozinkaSalt = salt
           },
           new Ljekar()
           {
               Id = 7,
               Ime = "Olivia",
               Prezime = "Taylor",
               Titula = TitulaLjekara.MedSestra,
               Sifra = "OT890",
               Username = "olivia",
               LozinkaHash = hash,
               LozinkaSalt = salt
           },
           new Ljekar()
           {
               Id = 8,
               Ime = "Benjamin",
               Prezime = "Anderson",
               Titula = TitulaLjekara.Specijalista,
               Sifra = "BA345",
               Username = "benjamin",
               LozinkaHash = hash,
               LozinkaSalt = salt
           },
           new Ljekar()
           {
               Id = 9,
               Ime = "Ljekar",
               Prezime = "Ljekar",
               Titula = TitulaLjekara.Specijalista,
               Sifra = "BR845",
               Username = "ljekar",
               LozinkaHash = hash,
               LozinkaSalt = salt
           }

   );
        }

        private void SeedPrijemPacijenta(ModelBuilder modelBuilder)
        {
           

            modelBuilder.Entity<PrijemPacijenta>().HasData(
                new PrijemPacijenta()
                {
                    Id = 1,
                    DatumIVrijemePrijema = new DateTime(2024, 3, 25, 12,0,0), 
                    PacijentId = 2,
                    NadlezniLjekarId = 2,
                    HitniPrijem = false
                },
                new PrijemPacijenta()
                {
                    Id = 2,
                    DatumIVrijemePrijema = new DateTime(2024, 3, 20, 11, 0, 0), 
                    PacijentId = 2,
                    NadlezniLjekarId = 3,
                    HitniPrijem = true
                },
                new PrijemPacijenta()
                {
                    Id = 3,
                    DatumIVrijemePrijema = new DateTime(2024, 3, 18, 9, 0, 0), 
                    PacijentId = 3,
                    NadlezniLjekarId = 4,
                    HitniPrijem = false
                },
                new PrijemPacijenta()
                {
                    Id = 4,
                    DatumIVrijemePrijema = new DateTime(2024, 3, 14, 8, 0, 0), 
                    PacijentId = 4,
                    NadlezniLjekarId = 5,
                    HitniPrijem = true
                },
                new PrijemPacijenta()
                {
                    Id = 5,
                    DatumIVrijemePrijema = new DateTime(2024, 3, 10, 2, 0, 0), 
                    PacijentId = 5,
                    NadlezniLjekarId = 6,
                    HitniPrijem = false
                },
                new PrijemPacijenta()
                {
                    Id = 6,
                    DatumIVrijemePrijema = new DateTime(2024, 3, 5, 4, 0, 0), 
                    PacijentId = 6,
                    NadlezniLjekarId = 7,
                    HitniPrijem = true
                },
                new PrijemPacijenta()
                {
                    Id = 7,
                    DatumIVrijemePrijema = new DateTime(2024, 3, 1, 1, 0, 0), 
                    PacijentId = 7,
                    NadlezniLjekarId = 8,
                    HitniPrijem = false
                },
                new PrijemPacijenta()
                {
                    Id = 8,
                    DatumIVrijemePrijema = new DateTime(2024, 2, 26, 3, 0, 0), 
                    PacijentId = 8,
                    NadlezniLjekarId = 9,
                    HitniPrijem = true
                },
                new PrijemPacijenta()
                {
                    Id = 9,
                    DatumIVrijemePrijema = new DateTime(2024, 2, 22, 4, 0, 0), 
                    PacijentId = 4,
                    NadlezniLjekarId = 3,
                    HitniPrijem = false
                },
                new PrijemPacijenta()
                {
                    Id = 10,
                    DatumIVrijemePrijema = new DateTime(2024, 2, 18, 5, 0, 0), 
                    PacijentId = 2,
                    NadlezniLjekarId = 4,
                    HitniPrijem = true
                }
            );
        }


        private void SeedNalaz(ModelBuilder modelBuilder)
        {
           modelBuilder.Entity<Nalaz>().HasData(
           new Nalaz()
            {
                Id = 1,
                TekstualniOpis = "Nalaz 1",
                PrijemPacijentaId = 1,
                DatumIVrijemeKreiranja = new DateTime(2024, 3, 25) 
            },
        new Nalaz()
        {
            Id = 2,
            TekstualniOpis = "Nalaz 2",
            PrijemPacijentaId = 2,
            DatumIVrijemeKreiranja = new DateTime(2024, 3, 20) 
        },
        new Nalaz()
        {
            Id = 3,
            TekstualniOpis = "Nalaz 3",
            PrijemPacijentaId = 3,
            DatumIVrijemeKreiranja = new DateTime(2024, 3, 18) 
        },
        new Nalaz()
        {
            Id = 4,
            TekstualniOpis = "Nalaz 4",
            PrijemPacijentaId = 4,
            DatumIVrijemeKreiranja = new DateTime(2024, 3, 14)
        },
        new Nalaz()
        {
            Id = 5,
            TekstualniOpis = "Nalaz 5",
            PrijemPacijentaId = 5,
            DatumIVrijemeKreiranja = new DateTime(2024, 3, 10) 
        }
    );
        }

    }

}
