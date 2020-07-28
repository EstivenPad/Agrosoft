using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrosoft.Migrations
{
    public partial class Migracion_Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    Direccion = table.Column<string>(nullable: false),
                    LimiteCredito = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobrosId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    Deposito = table.Column<decimal>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobrosId);
                });

            migrationBuilder.CreateTable(
                name: "CompraProductos",
                columns: table => new
                {
                    CompraId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ProveedorId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraProductos", x => x.CompraId);
                });

            migrationBuilder.CreateTable(
                name: "Marcas",
                columns: table => new
                {
                    MarcaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Marcas", x => x.MarcaId);
                });

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
                name: "Proveedores",
                columns: table => new
                {
                    ProveedorId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Nombres = table.Column<string>(nullable: false),
                    Apellidos = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    Rnc = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proveedores", x => x.ProveedorId);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesMedida",
                columns: table => new
                {
                    UnidadId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedida", x => x.UnidadId);
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
                    TipoUsuario = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "VentaProductos",
                columns: table => new
                {
                    VentaId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TipoFactura = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaProductos", x => x.VentaId);
                });

            migrationBuilder.CreateTable(
                name: "CompraProductosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CompraId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompraProductosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompraProductosDetalle_CompraProductos_CompraId",
                        column: x => x.CompraId,
                        principalTable: "CompraProductos",
                        principalColumn: "CompraId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VentaProductosDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    VentaId = table.Column<int>(nullable: false),
                    ProductoId = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    PrecioUnitario = table.Column<decimal>(nullable: false),
                    Importe = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VentaProductosDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VentaProductosDetalle_VentaProductos_VentaId",
                        column: x => x.VentaId,
                        principalTable: "VentaProductos",
                        principalColumn: "VentaId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "UnidadesMedida",
                columns: new[] { "UnidadId", "Descripcion" },
                values: new object[] { 1, "Saco 25 Lbs" });

            migrationBuilder.InsertData(
                table: "UnidadesMedida",
                columns: new[] { "UnidadId", "Descripcion" },
                values: new object[] { 2, "Saco 50 Lbs" });

            migrationBuilder.InsertData(
                table: "UnidadesMedida",
                columns: new[] { "UnidadId", "Descripcion" },
                values: new object[] { 3, "Saco 100 Lbs" });

            migrationBuilder.InsertData(
                table: "UnidadesMedida",
                columns: new[] { "UnidadId", "Descripcion" },
                values: new object[] { 4, "Saco 125 Lbs" });

            migrationBuilder.InsertData(
                table: "UnidadesMedida",
                columns: new[] { "UnidadId", "Descripcion" },
                values: new object[] { 5, "Saco 200 Lbs" });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "UsuarioId", "Apellidos", "Celular", "ClaveUsuario", "Direccion", "Email", "Fecha", "NombreUsuario", "Nombres", "Telefono", "TipoUsuario" },
                values: new object[] { 1, "Admin", "0123456789", "admin", "Admin", "Admin@hotmail.com", new DateTime(2020, 7, 28, 15, 27, 42, 636, DateTimeKind.Local).AddTicks(3710), "admin", "Admin", "0123456789", "Administrador" });

            migrationBuilder.CreateIndex(
                name: "IX_CompraProductosDetalle_CompraId",
                table: "CompraProductosDetalle",
                column: "CompraId");

            migrationBuilder.CreateIndex(
                name: "IX_VentaProductosDetalle_VentaId",
                table: "VentaProductosDetalle",
                column: "VentaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "CompraProductosDetalle");

            migrationBuilder.DropTable(
                name: "Marcas");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Proveedores");

            migrationBuilder.DropTable(
                name: "UnidadesMedida");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "VentaProductosDetalle");

            migrationBuilder.DropTable(
                name: "CompraProductos");

            migrationBuilder.DropTable(
                name: "VentaProductos");
        }
    }
}
