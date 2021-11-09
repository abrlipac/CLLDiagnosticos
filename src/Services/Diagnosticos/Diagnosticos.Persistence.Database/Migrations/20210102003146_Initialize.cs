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
                name: "Diagnosticos",
                schema: "Diagnosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Empleado_Id = table.Column<int>(type: "int", nullable: false),
                    Paciente_Id = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Enfermedad = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnosticos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetallesDiagnosticos",
                schema: "Diagnosticos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Diagnostico_Id = table.Column<int>(type: "int", nullable: false),
                    Sintoma = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_DetallesDiagnosticos_Diagnostico_Id",
                schema: "Diagnosticos",
                table: "DetallesDiagnosticos",
                column: "Diagnostico_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetallesDiagnosticos",
                schema: "Diagnosticos");

            migrationBuilder.DropTable(
                name: "Diagnosticos",
                schema: "Diagnosticos");
        }
    }
}
