using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;

namespace Revifast.Data
{
    public class HorarioMap : IEntityTypeConfiguration<Horario>
    {
        public void Configure(EntityTypeBuilder<Horario> builder)
        {
            // ID
            builder.ToTable("Horario")
                .HasKey(c => c.HorarioId);
            // HORA DE APERTURA
            builder.Property(c => c.HoraApertura)
                .HasColumnName("HoraApertura")
                .HasMaxLength(8)
                .IsUnicode(false);
            // HORA DE CIERRE
            builder.Property(c => c.HoraCierre)
                .HasColumnName("HoraCierre")
                .HasMaxLength(8)
                .IsUnicode(false);
            //Dia
            builder.Property(h=> h.Dia)
                .HasColumnName("Dia")
                .HasMaxLength(11)
                .IsUnicode(false);
            //Feriado
            builder.Property(f => f.Feriado)
                 .HasColumnName("Feriado")
                 .HasColumnType("bit");
        }
    }
}
