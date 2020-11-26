using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revifast.Data
{
    public class PromocionMap : IEntityTypeConfiguration<Promocion>
    {
        public void Configure(EntityTypeBuilder<Promocion> builder)
        {
            builder.ToTable("Promocion")
                .HasKey(p => p.PromocionId);
            builder.Property(p => p.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(20)
                .IsUnicode(false);
            builder.Property(p => p.Descuento)
                .HasColumnName("Descuento");
            builder.Property(p => p.Descripcion)
                .HasColumnName("Descripcion")
                .HasMaxLength(250)
                .IsUnicode(false);
            // ---------- HAS ONE
            builder.HasOne(d => d.Servicio)
                .WithMany(d => d.Promociones)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Servicio_Promocion");
        }
    }
}
