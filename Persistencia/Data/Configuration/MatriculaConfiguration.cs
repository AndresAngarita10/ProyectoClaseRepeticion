using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class MatriculaConfiguration: IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.ToTable("matricula");
        
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Id)
        .HasMaxLength(3);

        
    }
}
}