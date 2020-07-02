using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrosoft.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    ProductoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    Marca = table.Column<string>(nullable: false),
                    UnidadMedida = table.Column<int>(nullable: false),
                    CantidadMinima = table.Column<int>(nullable: false),
                    CantidadExistente = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false),
                    Costo = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.ProductoId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Nombres = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    NombreUsuario = table.Column<string>(nullable: false),
                    ClaveUsuario = table.Column<string>(nullable: false),
                    TipoUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
