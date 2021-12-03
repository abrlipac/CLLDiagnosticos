using Microsoft.EntityFrameworkCore.Migrations;

namespace Personal.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Personal");

            migrationBuilder.CreateTable(
                name: "Administradores",
                schema: "Personal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usuario_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Dni = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administradores", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Personal",
                table: "Administradores",
                columns: new[] { "Id", "Activo", "Apellidos", "Dni", "Nombres", "Usuario_Id" },
                values: new object[,]
                {
                    { 1, true, "Apellidos 1", "76368626", "Nombres 1", "1" },
                    { 2, true, "Apellidos 2", "76368627", "Nombres 2", "2" },
                    { 3, true, "Apellidos 3", "76368628", "Nombres 3", "3" },
                    { 4, true, "Apellidos 4", "76368629", "Nombres 4", "4" },
                    { 5, true, "Apellidos 5", "76368630", "Nombres 5", "5" },
                    { 6, true, "Apellidos 6", "76368631", "Nombres 6", "6" },
                    { 7, true, "Apellidos 7", "76368632", "Nombres 7", "7" },
                    { 8, true, "Apellidos 8", "76368633", "Nombres 8", "8" },
                    { 9, true, "Apellidos 9", "76368634", "Nombres 9", "9" },
                    { 10, true, "Apellidos 10", "76368635", "Nombres 10", "10" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_Dni",
                schema: "Personal",
                table: "Administradores",
                column: "Dni",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Administradores_Usuario_Id",
                schema: "Personal",
                table: "Administradores",
                column: "Usuario_Id",
                unique: true,
                filter: "[Usuario_Id] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administradores",
                schema: "Personal");
        }
    }
}
