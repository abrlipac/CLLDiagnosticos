using Microsoft.EntityFrameworkCore.Migrations;

namespace Personal.Persistence.Database.Migrations
{
    public partial class Inicializar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Personal");

            migrationBuilder.CreateTable(
                name: "Empleados",
                schema: "Personal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Personal",
                table: "Empleados",
                columns: new[] { "Id", "Activo", "Apellidos", "Dni", "Nombres" },
                values: new object[,]
                {
                    { 1, true, "Apellido 1", "76368626", "Nombre 1" },
                    { 2, true, "Apellido 2", "76368627", "Nombre 2" },
                    { 3, true, "Apellido 3", "76368628", "Nombre 3" },
                    { 4, true, "Apellido 4", "76368629", "Nombre 4" },
                    { 5, true, "Apellido 5", "76368630", "Nombre 5" },
                    { 6, true, "Apellido 6", "76368631", "Nombre 6" },
                    { 7, true, "Apellido 7", "76368632", "Nombre 7" },
                    { 8, true, "Apellido 8", "76368633", "Nombre 8" },
                    { 9, true, "Apellido 9", "76368634", "Nombre 9" },
                    { 10, true, "Apellido 10", "76368635", "Nombre 10" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Empleados",
                schema: "Personal");
        }
    }
}
