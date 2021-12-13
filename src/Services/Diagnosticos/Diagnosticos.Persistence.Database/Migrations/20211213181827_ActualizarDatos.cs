using Microsoft.EntityFrameworkCore.Migrations;

namespace Diagnosticos.Persistence.Database.Migrations
{
    public partial class ActualizarDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                schema: "Diagnosticos",
                table: "Opciones",
                columns: new[] { "Id", "Pregunta_Id", "Valor" },
                values: new object[] { 41, 21, "Sí" });

            migrationBuilder.InsertData(
                schema: "Diagnosticos",
                table: "Opciones",
                columns: new[] { "Id", "Pregunta_Id", "Valor" },
                values: new object[] { 42, 21, "No" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 42);
        }
    }
}
