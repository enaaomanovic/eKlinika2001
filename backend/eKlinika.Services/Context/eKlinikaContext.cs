using eKlinika.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;


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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            SeedData(modelBuilder);
            OnModelCreatingPartial(modelBuilder);
        }
       
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
