using eKlinika.Model;
using Microsoft.EntityFrameworkCore;


namespace eKlinika.Services.Context
{
    public partial class eKlinikaContext : DbContext
    {
        public eKlinikaContext(DbContextOptions<eKlinikaContext> options)
            : base(options)
        {
        }

       
        public virtual DbSet<Database.Pacijent> Pacijenti { get; set; }

        public virtual DbSet<Database.Ljekar> Ljekari { get; set; }
        public virtual DbSet<Database.PrijemPacijenta> PrijemPacijenta { get; set; }
        public virtual DbSet<Database.Nalaz> Nalazi { get; set; }

      
    }
}
