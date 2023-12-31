using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class PersonaConfiguration: IEntityTypeConfiguration<Persona>
{
    public void Configure(EntityTypeBuilder<Persona> builder)
    {
        builder.ToTable("persona");
        
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
        .HasMaxLength(3);
        
        builder.Property(p => p.Nombre)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Apellido)
        .IsRequired()
        .HasMaxLength(50);

        builder.Property(p => p.Direccion)
        .IsRequired()
        .HasMaxLength(100);

        builder.HasOne(p => p.Genero)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdGeneroFk);

        builder.HasOne(p => p.Ciudad)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdCiudadFk);

        builder.HasOne(p => p.TipoPersona)
        .WithMany(p => p.Personas)
        .HasForeignKey(p => p.IdTipoPerFk);

        builder
            .HasMany(p => p.Salones)
            .WithMany(p => p.Personas)
            .UsingEntity<TrainerSalon>(
                j => j
                    .HasOne(pt => pt.Salon)
                    .WithMany(t => t.TrainerSalones)
                    .HasForeignKey(pt => pt.IdSalonFk),
                j => j
                    .HasOne(pt => pt.Persona)
                    .WithMany(t => t.TrainerSalones)
                    .HasForeignKey(pt => pt.IdPerTrainerFk),
                j =>
                {
                    j.HasKey(t => new { t.IdPerTrainerFk, t.IdSalonFk});
                }
            );
    }
}
}