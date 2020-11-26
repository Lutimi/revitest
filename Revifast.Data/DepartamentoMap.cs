using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revifast.Data
{
    public class DepartamentoMap : IEntityTypeConfiguration<Departamento>
    {
        public void Configure(EntityTypeBuilder<Departamento> builder)
        {
            // ID
            builder.ToTable("Departamento")
                .HasKey(d => d.DepartamentoId);
            // NOMBRE
            builder.Property(d => d.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(20)
                .IsUnicode(false);
            // ---------- HAS ONE
        }
    }
}
