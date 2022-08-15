using Microsoft.EntityFrameworkCore;
using MyCNPJ.Entities;

namespace MyCNPJ.DataContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AtividadesPrincipais>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<AtividadesSecundarias>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Billing>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<CnpjData>()
                .HasKey(a => a.Id);
        }

        public virtual DbSet<CnpjData> CnpjData { get; set; }
    }
}
