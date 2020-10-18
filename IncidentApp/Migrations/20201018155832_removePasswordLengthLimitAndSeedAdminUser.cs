using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentApp.Migrations
{
    public partial class removePasswordLengthLimitAndSeedAdminUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Contrasena",
                table: "Usuarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "EmpleadoId", "FechaRegistro", "CreadoPor", "CreatorId", "Borrado", "Contrasena", "Estatus", "FechaModificacion", "ModificadoPor", "UpdaterId", "NombreUsuario" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, false, "OjmVqA/K4ro=", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 0, null, "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "EmpleadoId",
                keyValue: 1);

            migrationBuilder.AlterColumn<string>(
                name: "Contrasena",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
