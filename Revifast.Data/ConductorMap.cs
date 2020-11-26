using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;

namespace Revifast.Data
{
    public class ConductorMap : IEntityTypeConfiguration<Conductor>
    {
        public void Configure(EntityTypeBuilder<Conductor> builder)
        {
            // ID
            builder.ToTable("Conductor")
                .HasKey(c => c.ConductorId);
            // NOMBRE
            builder.Property(c => c.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(20)
                .IsUnicode(false);
            // APELLIDO
            builder.Property(c => c.Apellido)
                .HasColumnName("Apellido")
                .HasMaxLength(20)
                .IsUnicode(false);
            // DNI
            builder.Property(c => c.Dni)
                .HasColumnName("Dni")
                .HasMaxLength(8)
                .IsUnicode(false);
            // DIRECCION
            builder.Property(c => c.Direccion)
                .HasColumnName("Direccion")
                .HasMaxLength(250)
                .IsUnicode(false);
            // CELULAR
            builder.Property(c => c.Celular)
                .HasColumnName("Celular")
                .HasMaxLength(10)
                .IsUnicode(false);
            // CORREO
            builder.Property(c => c.Correo)
                .HasColumnName("Correo")
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
