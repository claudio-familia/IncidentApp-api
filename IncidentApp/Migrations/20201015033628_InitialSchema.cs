using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IncidentApp.Migrations
{
    public partial class InitialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    NombreUsuario = table.Column<string>(nullable: false),
                    Contrasena = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Usuarios_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Departamentos",
                columns: table => new
                {
                    DepartamentoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamentos", x => x.DepartamentoId);
                    table.ForeignKey(
                        name: "FK_Departamentos_Usuarios_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Departamentos_Usuarios_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SLAs",
                columns: table => new
                {
                    SLAId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    Descripcion = table.Column<string>(nullable: false),
                    CantidadHoras = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SLAs", x => x.SLAId);
                    table.ForeignKey(
                        name: "FK_SLAs_Usuarios_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SLAs_Usuarios_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Puestos",
                columns: table => new
                {
                    PuestoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Puestos", x => x.PuestoId);
                    table.ForeignKey(
                        name: "FK_Puestos_Usuarios_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Puestos_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Puestos_Usuarios_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Prioridades",
                columns: table => new
                {
                    PrioridadId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    SLAId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prioridades", x => x.PrioridadId);
                    table.ForeignKey(
                        name: "FK_Prioridades_Usuarios_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prioridades_SLAs_SLAId",
                        column: x => x.SLAId,
                        principalTable: "SLAs",
                        principalColumn: "SLAId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Prioridades_Usuarios_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    EmpleadoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    PuestoId = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false),
                    Apellido = table.Column<string>(maxLength: 100, nullable: false),
                    Cedula = table.Column<string>(maxLength: 11, nullable: false),
                    Correo = table.Column<string>(maxLength: 50, nullable: true),
                    Telefono = table.Column<string>(maxLength: 15, nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.EmpleadoId);
                    table.ForeignKey(
                        name: "FK_Empleados_Usuarios_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleados_Puestos_PuestoId",
                        column: x => x.PuestoId,
                        principalTable: "Puestos",
                        principalColumn: "PuestoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleados_Usuarios_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Empleados_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Incidentes",
                columns: table => new
                {
                    IncidenteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    UsuarioReportaId = table.Column<int>(nullable: false),
                    UsuarioAsignadoId = table.Column<int>(nullable: false),
                    PrioridadId = table.Column<int>(nullable: false),
                    DepartamentoId = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 200, nullable: false),
                    Descripcion = table.Column<string>(nullable: false),
                    FechaCierre = table.Column<DateTime>(nullable: false),
                    ComentarioCierre = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Incidentes", x => x.IncidenteId);
                    table.ForeignKey(
                        name: "FK_Incidentes_Usuarios_UsuarioAsignadoId",
                        column: x => x.UsuarioAsignadoId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId");
                    table.ForeignKey(
                        name: "FK_Incidentes_Usuarios_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Incidentes_Departamentos_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "Departamentos",
                        principalColumn: "DepartamentoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidentes_Prioridades_PrioridadId",
                        column: x => x.PrioridadId,
                        principalTable: "Prioridades",
                        principalColumn: "PrioridadId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Incidentes_Usuarios_UsuarioReportaId",
                        column: x => x.UsuarioReportaId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId");
                    table.ForeignKey(
                        name: "FK_Incidentes_Usuarios_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HistorialIncidentes",
                columns: table => new
                {
                    HistorialIncidenteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estatus = table.Column<string>(maxLength: 2, nullable: true),
                    Borrado = table.Column<bool>(nullable: false),
                    CreadoPor = table.Column<int>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    ModificadoPor = table.Column<int>(nullable: false),
                    FechaModificacion = table.Column<DateTime>(nullable: false),
                    CreatorId = table.Column<int>(nullable: true),
                    UpdaterId = table.Column<int>(nullable: true),
                    IncidenteId = table.Column<int>(nullable: false),
                    Comentario = table.Column<string>(maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistorialIncidentes", x => x.HistorialIncidenteId);
                    table.ForeignKey(
                        name: "FK_HistorialIncidentes_Usuarios_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_HistorialIncidentes_Incidentes_IncidenteId",
                        column: x => x.IncidenteId,
                        principalTable: "Incidentes",
                        principalColumn: "IncidenteId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HistorialIncidentes_Usuarios_UpdaterId",
                        column: x => x.UpdaterId,
                        principalTable: "Usuarios",
                        principalColumn: "EmpleadoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_CreatorId",
                table: "Departamentos",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Departamentos_UpdaterId",
                table: "Departamentos",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_CreatorId",
                table: "Empleados",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_PuestoId",
                table: "Empleados",
                column: "PuestoId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_UpdaterId",
                table: "Empleados",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_UsuarioId",
                table: "Empleados",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HistorialIncidentes_CreatorId",
                table: "HistorialIncidentes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialIncidentes_IncidenteId",
                table: "HistorialIncidentes",
                column: "IncidenteId");

            migrationBuilder.CreateIndex(
                name: "IX_HistorialIncidentes_UpdaterId",
                table: "HistorialIncidentes",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_UsuarioAsignadoId",
                table: "Incidentes",
                column: "UsuarioAsignadoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_CreatorId",
                table: "Incidentes",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_DepartamentoId",
                table: "Incidentes",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_PrioridadId",
                table: "Incidentes",
                column: "PrioridadId");

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_UsuarioReportaId",
                table: "Incidentes",
                column: "UsuarioReportaId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Incidentes_UpdaterId",
                table: "Incidentes",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Prioridades_CreatorId",
                table: "Prioridades",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Prioridades_SLAId",
                table: "Prioridades",
                column: "SLAId");

            migrationBuilder.CreateIndex(
                name: "IX_Prioridades_UpdaterId",
                table: "Prioridades",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_CreatorId",
                table: "Puestos",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_DepartamentoId",
                table: "Puestos",
                column: "DepartamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Puestos_UpdaterId",
                table: "Puestos",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_SLAs_CreatorId",
                table: "SLAs",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_SLAs_UpdaterId",
                table: "SLAs",
                column: "UpdaterId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CreatorId",
                table: "Usuarios",
                column: "CreatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_UpdaterId",
                table: "Usuarios",
                column: "UpdaterId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "HistorialIncidentes");

            migrationBuilder.DropTable(
                name: "Puestos");

            migrationBuilder.DropTable(
                name: "Incidentes");

            migrationBuilder.DropTable(
                name: "Departamentos");

            migrationBuilder.DropTable(
                name: "Prioridades");

            migrationBuilder.DropTable(
                name: "SLAs");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
