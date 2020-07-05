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

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Nombres = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Cedula = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                    table.ForeignKey(
                        name: "FK_Clientes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Apellidos", "Celular", "ClaveUsuario", "Direccion", "Email", "Fecha", "NombreUsuario", "Nombres", "Telefono", "TipoUsuario" },
                values: new object[] { 1, "Admin", "0123456789", "admin", "Admin", "Admin@hotmail.com", new DateTime(2020, 7, 5, 13, 12, 49, 520, DateTimeKind.Local).AddTicks(9167), "admin", "Admin", "0123456789", 1 });

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_UsuarioId",
                table: "Clientes",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
