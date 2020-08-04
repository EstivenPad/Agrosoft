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
            optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS; Database=Agrosoft; Trusted_Connection=True;");
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
                Descripcion= "Cc"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 2,
                Descripcion = "Frasco 10 cc"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 3,
                Descripcion = "Frasco 25 cc"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 4,
                Descripcion = "Frasco 100 cc"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 5,
                Descripcion = "Frasco 250 cc"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 6,
                Descripcion = "Galón 5 litros"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 7,
                Descripcion = "Galón 10 litros"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 8,
                Descripcion = "Galón 20 litros"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 9,
                Descripcion = "Libra(s)"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 10,
                Descripcion = "Litro(s)"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 11,
                Descripcion = "Pinta(s)"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 12,
                Descripcion = "Saco 25 libras"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 13,
                Descripcion = "Saco 50 libras"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 14,
                Descripcion = "Saco 55 libras"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 15,
                Descripcion = "Saco 50 libras"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 16,
                Descripcion = "Saco 100 libras"
            });
            modelBuilder.Entity<UnidadesMedida>().HasData(new UnidadesMedida
            {
                UnidadId = 17,
                Descripcion = "Saco 125 libras"
            });
            //Marcas
            modelBuilder.Entity<Marcas>().HasData(new Marcas
            {
                MarcaId = 1,
                Descripcion = "Fersan"
            });
            modelBuilder.Entity<Marcas>().HasData(new Marcas
            {
                MarcaId = 2,
                Descripcion = "Ferquido"
            });
            modelBuilder.Entity<Marcas>().HasData(new Marcas
            {
                MarcaId = 3,
                Descripcion = "Jaragua"
            });
            modelBuilder.Entity<Marcas>().HasData(new Marcas
            {
                MarcaId = 4,
                Descripcion = "Quisqueya"
            });
            modelBuilder.Entity<Marcas>().HasData(new Marcas
            {
                MarcaId = 5,
                Descripcion = "Puita"
            });
        }
    }
}
