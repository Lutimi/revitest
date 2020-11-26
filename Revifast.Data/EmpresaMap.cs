using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;

namespace Revifast.Data
{
    public class EmpresaMap : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            // ID
            builder.ToTable("Empresa")
                .HasKey(c => c.EmpresaId);
            // NOMBRE
            builder.Property(c => c.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(20)
                .IsUnicode(false);
            // RUC
            builder.Property(c => c.Ruc)
                .HasColumnName("Ruc")
                .HasMaxLength(10)
                .IsUnicode(false);
            // TELEFONO
            builder.Property(c => c.Telefono)
                .HasColumnName("Telefono")
                .HasMaxLength(10)
                .IsUnicode(false);
            // CORREO
            builder.Property(c => c.Correo)
                .HasColumnName("Correo")
                .HasMaxLength(50)
                .IsUnicode(false);
            // ---------- HAS ONE
            // NO
        }
    }
}
