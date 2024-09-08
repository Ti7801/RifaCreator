using BibliotecaBusiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaData.TableConfig
{
    public class AfiliadoTableConfig : IEntityTypeConfiguration<Afiliado>
    {
        public void Configure(EntityTypeBuilder<Afiliado> builder)
        {
            builder.ToTable("Afiliado");

            builder.HasKey(afiliado => afiliado.Id);

            builder.Property(afiliado => afiliado.Nome)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(afiliado => afiliado.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(afiliado => afiliado.Telefone)
                .IsRequired()
                .HasMaxLength(15);

            builder.HasMany<Bilhete>()
                .WithOne()
                .HasForeignKey(bilhete => bilhete.AfiliadoId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
