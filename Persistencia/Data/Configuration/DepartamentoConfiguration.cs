using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class DepartamentoConfiguration: IEntityTypeConfiguration<Departamento>
{
    public void Configure(EntityTypeBuilder<Departamento> builder)
    {
        builder.ToTable("departamento");
        
        builder.HasKey(d => d.Id);
        builder.Property(d => d.Id)
        .HasMaxLength(3);

        builder.Property(d => d.NombreDep)
        .IsRequired()
        .HasMaxLength(50);

        builder.HasOne(d => d.Pais)
        .WithMany(d => d.Departamentos)
        .HasForeignKey(d => d.IdPaisFk);
    }
}
}