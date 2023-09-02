using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PaisConfiguration: IEntityTypeConfiguration<Pais>
{
    public void Configure(EntityTypeBuilder<Pais> builder)
    {
        builder.ToTable("pais");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
        .HasMaxLength(3);

        builder.Property(p => p.NombrePais)
        .IsRequired()
        .HasMaxLength(50);
    }
}
}