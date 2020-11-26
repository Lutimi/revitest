using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Revifast.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revifast.Data
{
    public class DistritoMap : IEntityTypeConfiguration<Distrito>
    {
        public void Configure(EntityTypeBuilder<Distrito> builder)
        {
            // ID
            builder.ToTable("Distrito")
                .HasKey(d => d.DistritoId);
            // NOMBRE
            builder.Property(d => d.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
