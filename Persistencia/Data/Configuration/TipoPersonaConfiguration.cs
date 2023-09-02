using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class TipoPersonaConfiguration: IEntityTypeConfiguration<TipoPersona>
{
    public void Configure(EntityTypeBuilder<TipoPersona> builder)
    {
        builder.ToTable("tipoPersona");
        
        builder.HasKey(t => t.Id);
        builder.Property(t => t.Id)
        .HasMaxLength(3);

        builder.Property(t => t.DescripcionTipoP)
        .IsRequired()
        .HasMaxLength(50);
    }
}
}