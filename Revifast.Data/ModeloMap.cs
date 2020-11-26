using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;

namespace Revifast.Data
{
    public class ModeloMap : IEntityTypeConfiguration<Modelo>
    {
        public void Configure(EntityTypeBuilder<Modelo> builder)
        {
            // ID
            builder.ToTable("Modelo")
                .HasKey(m => m.ModeloId);
            // NOMBRE
            builder.Property(m => m.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(20);
            // ---------- HAS ONE
            // MARCA
            builder.HasOne(m => m.Marca)
                .WithMany(m => m.Modelos)
                .HasForeignKey(m => m.MarcaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Modelo_Marca");
        }
    }
}
