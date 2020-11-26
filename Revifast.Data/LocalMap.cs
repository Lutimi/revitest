using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;

namespace Revifast.Data
{
    public class LocalMap : IEntityTypeConfiguration<Local>
    {
        public void Configure(EntityTypeBuilder<Local> builder)
        {
            // ID
            builder.ToTable("Local")
                .HasKey(l => l.LocalId);
            // DIRECCION
            builder.Property(l => l.Direccion)
                .HasColumnName("Direccion")
                .HasMaxLength(250)
                .IsUnicode(false);
            // ---------- HAS ONE
            // HORARIO
            builder.HasOne(l => l.Horario)
               .WithMany(l => l.Locales)
               .HasForeignKey(l => l.HorarioId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("Local_Horario");
            // EMPRESA
            builder.HasOne(l => l.Empresa)
               .WithMany(l => l.Locales)
               .HasForeignKey(l => l.EmpresaId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("Local_Empresa");
            // DISTRITO
            builder.HasOne(l => l.Distrito)
               .WithMany(l => l.Locales)
               .HasForeignKey(l => l.DistritoId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("Local_Distrito");
        }
    }
}
