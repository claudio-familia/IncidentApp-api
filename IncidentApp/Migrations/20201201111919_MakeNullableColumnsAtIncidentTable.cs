using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentApp.Migrations
{
    public partial class MakeNullableColumnsAtIncidentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Departamentos_DepartamentoId",
                table: "Incidentes");

            migrationBuilder.DropIndex(
                name: "IX_Incidentes_UsuarioAsignadoId",
                table: "Incidentes");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Incidentes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCierre",
                table: "Incidentes",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioAsignadoId",
                table: "Incidentes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Departamentos_DepartamentoId",
                table: "Incidentes",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Incidentes_Departamentos_DepartamentoId",
                table: "Incidentes");

            migrationBuilder.DropIndex(
                name: "IX_Incidentes_UsuarioAsignadoId",
                table: "Incidentes");

            migrationBuilder.AlterColumn<int>(
                name: "DepartamentoId",
                table: "Incidentes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "FechaCierre",
                table: "Incidentes",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioAsignadoId",
                table: "Incidentes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "EmpleadoId",
                keyValue: 1,
                column: "Estatus",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_UsuarioAsignadoId",
                table: "Incidentes",
                column: "UsuarioAsignadoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Incidentes_Departamentos_DepartamentoId",
                table: "Incidentes",
                column: "DepartamentoId",
                principalTable: "Departamentos",
                principalColumn: "DepartamentoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
