using Microsoft.EntityFrameworkCore;
using Revifast.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Revifast.Data
{
    public class DbRevifastContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Conductor> Conductores { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Modelo> Modelos { get; set; }
        public DbSet<Vehiculo> Vehiculos { get; set; }
        // 2do
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Distrito> Distritos { get; set; }
        // 3ro
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Horario> Horarios { get; set; }
        public DbSet<Local> Locales { get; set; }
        public DbSet<Servicio> Servicios { get; set; }
        // 4to
        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
        public DbSet<ReservaEstado> ReservaEstados { get; set; }

        public DbRevifastContext(DbContextOptions<DbRevifastContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new CategoriaMap());
            modelBuilder.ApplyConfiguration(new ConductorMap());
            modelBuilder.ApplyConfiguration(new DepartamentoMap());
            modelBuilder.ApplyConfiguration(new DistritoMap());
            modelBuilder.ApplyConfiguration(new EmpresaMap());
            modelBuilder.ApplyConfiguration(new HorarioMap());
            modelBuilder.ApplyConfiguration(new LocalMap());
            modelBuilder.ApplyConfiguration(new MarcaMap());
            modelBuilder.ApplyConfiguration(new ModeloMap());
            modelBuilder.ApplyConfiguration(new PromocionMap());
            modelBuilder.ApplyConfiguration(new ReservaEstadoMap());
            modelBuilder.ApplyConfiguration(new ReservaMap());
            modelBuilder.ApplyConfiguration(new ServicioMap());
            modelBuilder.ApplyConfiguration(new VehiculoMap());


            Empresas.Add(
                new Empresa
                {
                    EmpresaId = 1,
                    Nombre = "Tesla",
                    Ruc = "NUMERORARO",
                    Telefono = "946183018",
                    Correo = "teslamotors@gmail.com",
                }
                
                );
        }

    }
}