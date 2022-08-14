using Microsoft.EntityFrameworkCore;
using MyCNPJ.Entities;

namespace MyCNPJ.DataContext
{
    public class DataContext : DbContext
    {
        private readonly string _connectionString;

        public DataContext() { }
        public DataContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
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
