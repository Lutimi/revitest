using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;

namespace Revifast.Data
{
    public class VehiculoMap : IEntityTypeConfiguration<Vehiculo>
    {
        public void Configure(EntityTypeBuilder<Vehiculo> builder)
        {
            // ID
            builder.ToTable("Vehiculo")
                .HasKey(v => v.VehiculoId);
            // PLACA
            builder.Property(v => v.Placa)
                .HasColumnName("Placa")
                .HasMaxLength(10)
                .IsUnicode(false);
            // COLOR
            builder.Property(v => v.Color)
                .HasColumnName("Color")
                .HasMaxLength(10)
                .IsUnicode(false);
            // FECHA FABRICACION
            builder.Property(v => v.FechaFabricacion)
                .HasColumnName("FechaFabricacion");
            // ---------- HAS ONE
            // CONDUCTOR
            builder.HasOne(v => v.Conductor)
               .WithMany(v => v.Vehiculos)
               .HasForeignKey(v => v.ConductorId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("Vehiculo_Conductor");
            // CATEGORIA
            builder.HasOne(v => v.Categoria)
               .WithMany(v => v.Vehiculos)
               .HasForeignKey(v => v.CategoriaId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("Vehiculo_Categoria");
            // MODELO
            builder.HasOne(v => v.Modelo)
               .WithMany(v => v.Vehiculos)
               .HasForeignKey(v => v.ModeloId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("Vehiculo_Modelo");
        }
    }
}
