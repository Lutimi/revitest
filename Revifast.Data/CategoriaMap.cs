using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;

namespace Revifast.Data
{
    public class CategoriaMap : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            // ID
            builder.ToTable("Categoria")
                .HasKey(c => c.CategoriaId);
            // NOMBRE
            builder.Property(c => c.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(10)
                .IsUnicode(false);
            // DESCRIPCION
            builder.Property(c => c.Descripcion)
                .HasColumnName("Descripcion")
                .HasMaxLength(250)
                .IsUnicode(false)
                .IsRequired(true);
        }
    }
}
