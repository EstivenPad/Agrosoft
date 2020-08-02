using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Agrosoft.Migrations
{
    public partial class RNC : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2020, 8, 1, 18, 38, 53, 684, DateTimeKind.Local).AddTicks(2938));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2020, 8, 1, 18, 38, 53, 682, DateTimeKind.Local).AddTicks(5406));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Clientes",
                keyColumn: "ClienteId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2020, 8, 1, 18, 33, 20, 6, DateTimeKind.Local).AddTicks(7199));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "UsuarioId",
                keyValue: 1,
                column: "Fecha",
                value: new DateTime(2020, 8, 1, 18, 33, 20, 3, DateTimeKind.Local).AddTicks(5071));
        }
    }
}
