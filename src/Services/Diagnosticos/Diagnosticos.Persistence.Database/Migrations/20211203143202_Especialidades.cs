using Microsoft.EntityFrameworkCore.Migrations;

namespace Diagnosticos.Persistence.Database.Migrations
{
    public partial class Especialidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "Diagnosticos",
                table: "Especialidades",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255);

            migrationBuilder.InsertData(
                schema: "Diagnosticos",
                table: "Especialidades",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 1, "Es la rama de la medicina que se especializa en la salud y las enfermedades de los niños. Se trata de una especialidad médica que se centra en los pacientes desde el momento del nacimiento hasta la adolescencia.", "Pediatría" });

            migrationBuilder.InsertData(
                schema: "Diagnosticos",
                table: "Especialidades",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 2, "La cardiología es la rama de la medicina que se encarga del estudio, diagnóstico y tratamiento de las enfermedades del corazón y del aparato circulatorio.", "Cardiología" });

            migrationBuilder.InsertData(
                schema: "Diagnosticos",
                table: "Especialidades",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 3, "Es la especialidad médica que se ocupa de las enfermedades del aparato digestivo y órganos asociados, conformado por: esófago, estómago, hígado y vías biliares, páncreas, intestino delgado (duodeno, yeyuno, íleon), colon y recto. El médico que practica esta especialidad se llama gastroenterólogo o especialista en aparato digestivo.", "Gastroenterología" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                schema: "Diagnosticos",
                table: "Especialidades",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
