using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class SalonConfiguration: IEntityTypeConfiguration<Salon>
{
    public void Configure(EntityTypeBuilder<Salon> builder)
    {
        builder.ToTable("salon");
        
        builder.HasKey(s => s.Id);
        builder.Property(s => s.Id)
        .HasMaxLength(3);

        builder.Property(s => s.NombreSalon)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(s => s.Capacidad)
        .IsRequired()
        .HasColumnType("int");
    }
}
}