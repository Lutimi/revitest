using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;

namespace Revifast.Data
{
    public class ServicioMap : IEntityTypeConfiguration<Servicio>
    {
        public void Configure(EntityTypeBuilder<Servicio> builder)
        {
            // ID
            builder.ToTable("Servicio")
                .HasKey(s => s.ServicioId);
            // NOMBRE
            builder.Property(s => s.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(20)
                .IsUnicode(false);
            // DESCRIPCION
            builder.Property(s => s.Descripcion)
                .HasColumnName("Descripcion")
                .HasMaxLength(250)
                .IsUnicode(false);
            // ---------- HAS ONE
            // LOCAL
            builder.HasOne(s => s.Local)
               .WithMany(s => s.Servicios)
               .HasForeignKey(s => s.LocalId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("Servicio_Local");
            // CATEGORIA
            builder.HasOne(s => s.Categoria)
               .WithMany(s => s.Servicios)
               .HasForeignKey(s => s.CategoriaId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("Servicio_Categoria");
        }
    }
}
