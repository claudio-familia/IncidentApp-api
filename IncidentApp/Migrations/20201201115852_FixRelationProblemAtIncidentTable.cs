using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentApp.Migrations
{
    public partial class FixRelationProblemAtIncidentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Incidentes_UsuarioAsignadoId",
                table: "Incidentes");

            migrationBuilder.DropIndex(
                name: "IX_Incidentes_UsuarioReportaId",
                table: "Incidentes");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "EmpleadoId",
                keyValue: 1,
                column: "Estatus",
                value: "1");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_UsuarioAsignadoId",
                table: "Incidentes",
                column: "UsuarioAsignadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_UsuarioReportaId",
                table: "Incidentes",
                column: "UsuarioReportaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Incidentes_UsuarioAsignadoId",
                table: "Incidentes");

            migrationBuilder.DropIndex(
                name: "IX_Incidentes_UsuarioReportaId",
                table: "Incidentes");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "EmpleadoId",
                keyValue: 1,
                column: "Estatus",
                value: "1");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_UsuarioAsignadoId",
                table: "Incidentes",
                column: "UsuarioAsignadoId",
                unique: true,
                filter: "[UsuarioAsignadoId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_UsuarioReportaId",
                table: "Incidentes",
                column: "UsuarioReportaId",
                unique: true);
        }
    }
}
