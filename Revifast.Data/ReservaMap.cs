using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revifast.Data
{
    public class ReservaMap : IEntityTypeConfiguration<Reserva>
    {
        public void Configure(EntityTypeBuilder<Reserva> builder)
        {
            // ID
            builder.ToTable("Reserva")
                .HasKey(r => r.ReservaId);
            // FECHA
            builder.Property(a => a.Fecha)
                .HasColumnName("Fecha")
                .HasMaxLength(10)
                .IsUnicode(false);
            // HORA
            builder.Property(a => a.Hora)
                .HasColumnName("Hora")
                .HasMaxLength(8)
                .IsUnicode(false);
            // OBSERVACIONES
            builder.Property(a => a.Observaciones)
                .HasColumnName("Observaciones")
                .HasMaxLength(250)
                .IsUnicode(false);
            // VEHICULO
            builder.HasOne(r => r.Vehiculo)
                .WithMany(r => r.Reservas)
                .HasForeignKey(r => r.VehiculoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Reserva_Vehiculo");
            // LOCAL
            builder.HasOne(r => r.Local)
                .WithMany(r => r.Reservas)
                .HasForeignKey(r => r.LocalId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Reserva_Local");
            // RESERVA ESTADO
            builder.HasOne(r => r.ReservaEstado)
                .WithMany(r => r.Reservas)
                .HasForeignKey(r => r.ReservaEstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Reserva_ReservaEstado");

        }
    }
}
