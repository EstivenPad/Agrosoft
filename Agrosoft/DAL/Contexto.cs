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
        public DbSet<Clientes> Clientes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source = DATA\Agrosoft.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios{
                UsuarioId = 1,
                Fecha = DateTime.Now,
                Nombres = "Admin",
                Apellidos = "Admin",
                Telefono = "0123456789",
                Celular = "0123456789",
                Email = "Admin@hotmail.com",
                Direccion = "Admin",
                NombreUsuario = "admin",
                ClaveUsuario = "admin",
                TipoUsuario = 1
            });
        }
    }
}
