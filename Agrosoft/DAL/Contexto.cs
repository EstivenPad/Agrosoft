using Agrosoft.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Agrosoft.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<UnidadesMedida> UnidadesMedida { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Proveedores> Proveedores { get; set; }
        public DbSet<CompraProductos> CompraProductos { get; set; }
        public DbSet<VentaProductos> VentaProductos { get; set; }
        public DbSet<Cobros> Cobros { get; set; }
        public DbSet<Marcas> Marcas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\Agrosoft.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Usuario
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios{
                UsuarioId = 1,
                Fecha = DateTime.Now,
                Nombres = "Admin",
                Apellidos = "Admin",
                Telefono = "0123456789",
                Celular = "0123456789",
                Email = "Admin@hotmail.com",
                Direccion = "Admin",
                NombreUsuario = "Admin",
                ClaveUsuario = "admin",
                ClaveConfirmada = "admin",
                TipoUsuario = "Administrador"
            });

            //Cliente
            modelBuilder.Entity<Clientes>().HasData(new Clientes
            {
                ClienteId=1,
                UsuarioId = 1,
                Fecha = DateTime.Now,
                Nombres = "Cliente",
                Apellidos = "ocasional",
                Cedula="00000000000",
                Telefono = "0000000000",
                Celular = "0000000000",
                Email = "clienteOcasional@hotmail.com",
                Direccion = "xxxxxxxxxxxxx",
                LimiteCredito = 0,
                Balance = 0,
            });
            //Unidades de medida
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 1,
                Descripcion= "Saco 25 Lbs"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 2,
                Descripcion = "Saco 50 Lbs"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 3,
                Descripcion = "Saco 100 Lbs"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 4,
                Descripcion = "Saco 125 Lbs"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 5,
                Descripcion = "Saco 200 Lbs"
            });
        }
    }
}
