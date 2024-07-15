using BibliotecaBusiness.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace BibliotecaData.TableConfig
{
    public class BilheteTableConfig : IEntityTypeConfiguration<Bilhete>
    {

        public void Configure(EntityTypeBuilder<Bilhete> builder)
        {
            builder.ToTable("Bilhete");

            builder.HasKey(bilhete => bilhete.Id);

            builder.Property(bilhete => bilhete.Nome)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(bilhete => bilhete.Telefone)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(bilhete => bilhete.Email)
                .IsRequired()
                .HasMaxLength(30);
        }
    }
}
