using BibliotecaBusiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BibliotecaData.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Bilhete> Bilhetes { get; set; }

        public DbSet<Rifa> Rifas { get; set; }

        public DbSet<Rifador> Rifadores { get; set; }

        public DbSet<Afiliado> Afiliados { get; set; }

        public AppDbContext(DbContextOptions options) : base (options) { }

        /// pra que serve mesmo? Reconhecer todo o assembly?
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
