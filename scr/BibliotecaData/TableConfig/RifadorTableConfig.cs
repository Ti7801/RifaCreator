using BibliotecaBusiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaData.TableConfig
{
    public class RifadorTableConfig : IEntityTypeConfiguration<Rifador>
    {

        public void Configure(EntityTypeBuilder<Rifador> builder)
        {
            builder.ToTable("Rifador");

            builder.HasKey(rifador => rifador.Id);

            builder.Property(rifador => rifador.Nome)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(rifador => rifador.Senha)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(rifador => rifador.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(rifador => rifador.Telefone)
                .IsRequired()
                .HasMaxLength(20);

            builder.HasMany<Rifa>()
               .WithOne()
               .HasForeignKey(rifa => rifa.RifadorId);
        }
    }
}
