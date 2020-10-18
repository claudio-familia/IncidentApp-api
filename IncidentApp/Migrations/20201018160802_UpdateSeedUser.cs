using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentApp.Migrations
{
    public partial class UpdateSeedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "EmpleadoId",
                keyValue: 1,
                columns: new[] { "Contrasena", "NombreUsuario" },
                values: new object[] { "ylwYeR9FMHE=", "Administrator" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "EmpleadoId",
                keyValue: 1,
                columns: new[] { "Contrasena", "NombreUsuario" },
                values: new object[] { "OjmVqA/K4ro=", "Admin" });
        }
    }
}
