using System;
using System.ComponentModel.DataAnnotations;

namespace eKlinika.Model
{
    public class PrijemPacijenta
    {
        [Key]
        public int Id { get; set; }
        [Required]

        public DateTime DatumIVrijemePrijema { get; set; }
        [Required]

        public Pacijent Pacijent { get; set; }
        [Required]

        public Ljekar NadlezniLjekar { get; set; }
        [Required]

        public bool HitniPrijem { get; set; }
    }
}
