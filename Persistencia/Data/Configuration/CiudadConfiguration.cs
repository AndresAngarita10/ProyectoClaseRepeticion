

using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration;

public class CiudadConfiguration : IEntityTypeConfiguration<Ciudad>
{
    public void Configure(EntityTypeBuilder<Ciudad> builder)
    {
        builder.ToTable("ciudad");

        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id)
        .HasMaxLength(3);

        builder.Property(c => c.NombreCiudad)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(c => c.Departamento)
        .WithMany(c => c.Ciudades)
        .HasForeignKey(c => c.IdDepFk);
    }
}
