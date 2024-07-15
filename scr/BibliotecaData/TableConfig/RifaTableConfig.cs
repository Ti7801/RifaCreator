using BibliotecaBusiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BibliotecaData.TableConfig
{
    public class RifaTableConfig : IEntityTypeConfiguration<Rifa>
    {

        public void Configure(EntityTypeBuilder<Rifa> builder)
        {
            builder.ToTable("Rifa");

            builder.HasKey(rifa => rifa.Id);

            builder.Property(rifa => rifa.Status)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(rifa => rifa.RifadorId)
            .IsRequired();

            builder.HasMany<Bilhete>()
                .WithOne()
                .HasForeignKey(bilhete => bilhete.RifaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
