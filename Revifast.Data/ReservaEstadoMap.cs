using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revifast.Data
{
    public class ReservaEstadoMap : IEntityTypeConfiguration<ReservaEstado>
    {
        public void Configure(EntityTypeBuilder<ReservaEstado> builder)
        {
            builder.ToTable("ReservaEstado")
                .HasKey(a => a.ReservaEstadoId);
            builder.Property(a => a.Estado)
                .HasColumnName("Estado")
                .HasMaxLength(20)
                .IsUnicode(false);

        }
    }
}
