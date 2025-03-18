using Microsoft.EntityFrameworkCore;
using Cops.Models;

namespace Cops.Data
{
    public class CopsContext : DbContext
    {
        public CopsContext(DbContextOptions<CopsContext> options)
            : base(options)
        {
        }

        public DbSet<Anagrafica> Anagrafica { get; set; }
        public DbSet<Verbale> Verbale { get; set; }
        public DbSet<TipoViolazione> TipoViolazione { get; set; }

        public DbSet<Statistiche> Statistiche { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Verbale>()
                .HasOne(v => v.Anagrafica)
                .WithMany(a => a.Verbali)
                .HasForeignKey(v => v.IdAnagrafica)
                .OnDelete(DeleteBehavior.Cascade);

           
            modelBuilder.Entity<Verbale>()
                .HasOne(v => v.TipoViolazione)
                .WithMany()
                .HasForeignKey(v => v.IdViolazione)
                .OnDelete(DeleteBehavior.Cascade);

           
            modelBuilder.Entity<Statistiche>()
                .HasOne(s => s.Anagrafica)
                .WithMany()
                .HasForeignKey(s => s.IdAnagrafica)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
