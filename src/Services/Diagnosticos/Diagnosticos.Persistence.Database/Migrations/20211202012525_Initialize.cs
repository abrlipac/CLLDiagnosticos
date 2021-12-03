using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diagnosticos.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Diagnosticos");

            migrationBuilder.CreateTable(
                name: "Enfermedades",
                schema: "Diagnosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Especialidades",
                schema: "Diagnosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especialidades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diagnosticos",
                schema: "Diagnosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Paciente_Id = table.Column<int>(type: "int", nullable: false),
                    Especialidad_Id = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Diagnosticos_Especialidades_Especialidad_Id",
                        column: x => x.Especialidad_Id,
                        principalSchema: "Diagnosticos",
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Preguntas",
                schema: "Diagnosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Especialidad_Id = table.Column<int>(type: "int", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    TieneOpciones = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preguntas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Preguntas_Especialidades_Especialidad_Id",
                        column: x => x.Especialidad_Id,
                        principalSchema: "Diagnosticos",
                        principalTable: "Especialidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PosiblesEnfermedades",
                schema: "Diagnosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Enfermedad_Id = table.Column<int>(type: "int", nullable: false),
                    Diagnostico_Id = table.Column<int>(type: "int", nullable: false),
                    Porcentaje = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PosiblesEnfermedades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PosiblesEnfermedades_Diagnosticos_Diagnostico_Id",
                        column: x => x.Diagnostico_Id,
                        principalSchema: "Diagnosticos",
                        principalTable: "Diagnosticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PosiblesEnfermedades_Enfermedades_Enfermedad_Id",
                        column: x => x.Enfermedad_Id,
                        principalSchema: "Diagnosticos",
                        principalTable: "Enfermedades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetallesDiagnosticos",
                schema: "Diagnosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnostico_Id = table.Column<int>(type: "int", nullable: false),
                    Pregunta_Id = table.Column<int>(type: "int", nullable: false),
                    Respuesta = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetallesDiagnosticos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetallesDiagnosticos_Diagnosticos_Diagnostico_Id",
                        column: x => x.Diagnostico_Id,
                        principalSchema: "Diagnosticos",
                        principalTable: "Diagnosticos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetallesDiagnosticos_Preguntas_Diagnostico_Id",
                        column: x => x.Diagnostico_Id,
                        principalSchema: "Diagnosticos",
                        principalTable: "Preguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Opciones",
                schema: "Diagnosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pregunta_Id = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Opciones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Opciones_Preguntas_Pregunta_Id",
                        column: x => x.Pregunta_Id,
                        principalSchema: "Diagnosticos",
                        principalTable: "Preguntas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesDiagnosticos_Diagnostico_Id",
                schema: "Diagnosticos",
                table: "DetallesDiagnosticos",
                column: "Diagnostico_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnosticos_Especialidad_Id",
                schema: "Diagnosticos",
                table: "Diagnosticos",
                column: "Especialidad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Opciones_Pregunta_Id",
                schema: "Diagnosticos",
                table: "Opciones",
                column: "Pregunta_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PosiblesEnfermedades_Diagnostico_Id",
                schema: "Diagnosticos",
                table: "PosiblesEnfermedades",
                column: "Diagnostico_Id");

            migrationBuilder.CreateIndex(
                name: "IX_PosiblesEnfermedades_Enfermedad_Id",
                schema: "Diagnosticos",
                table: "PosiblesEnfermedades",
                column: "Enfermedad_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Preguntas_Especialidad_Id",
                schema: "Diagnosticos",
                table: "Preguntas",
                column: "Especialidad_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesDiagnosticos",
                schema: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Opciones",
                schema: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "PosiblesEnfermedades",
                schema: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Preguntas",
                schema: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Diagnosticos",
                schema: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Enfermedades",
                schema: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Especialidades",
                schema: "Diagnosticos");
        }
    }
}
