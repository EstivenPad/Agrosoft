using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrosoft.Migrations
{
    public partial class Migracion_Cobros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobrosId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<int>(nullable: false),
                    Deposito = table.Column<decimal>(nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    LimiteCredito = table.Column<decimal>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobrosId);
                });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2020, 7, 14, 16, 23, 26, 399, DateTimeKind.Local).AddTicks(2282));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2020, 7, 7, 12, 35, 2, 552, DateTimeKind.Local).AddTicks(735));
        }
    }
}
