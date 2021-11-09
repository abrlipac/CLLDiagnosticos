using Microsoft.EntityFrameworkCore.Migrations;

namespace Clientes.Persistence.Database.Migrations
{
    public partial class Inicializar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Clientes");

            migrationBuilder.CreateTable(
                name: "Pacientes",
                schema: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dni = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Celular = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: true),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Clientes",
                table: "Pacientes",
                columns: new[] { "Id", "Activo", "Apellidos", "Celular", "Dni", "Email", "Nombres", "Sexo" },
                values: new object[,]
                {
                    { 1, true, "Apellido 1", "+51942024657", "76368636", "paciente1@gmail.com", "Nombre 1", 1 },
                    { 73, true, "Apellido 73", "+51942024729", "76368708", "paciente73@gmail.com", "Nombre 73", 1 },
                    { 72, true, "Apellido 72", "+51942024728", "76368707", "paciente72@gmail.com", "Nombre 72", 0 },
                    { 71, true, "Apellido 71", "+51942024727", "76368706", "paciente71@gmail.com", "Nombre 71", 1 },
                    { 70, true, "Apellido 70", "+51942024726", "76368705", "paciente70@gmail.com", "Nombre 70", 0 },
                    { 69, true, "Apellido 69", "+51942024725", "76368704", "paciente69@gmail.com", "Nombre 69", 1 },
                    { 68, true, "Apellido 68", "+51942024724", "76368703", "paciente68@gmail.com", "Nombre 68", 0 },
                    { 67, true, "Apellido 67", "+51942024723", "76368702", "paciente67@gmail.com", "Nombre 67", 1 },
                    { 66, true, "Apellido 66", "+51942024722", "76368701", "paciente66@gmail.com", "Nombre 66", 0 },
                    { 65, true, "Apellido 65", "+51942024721", "76368700", "paciente65@gmail.com", "Nombre 65", 1 },
                    { 64, true, "Apellido 64", "+51942024720", "76368699", "paciente64@gmail.com", "Nombre 64", 0 },
                    { 63, true, "Apellido 63", "+51942024719", "76368698", "paciente63@gmail.com", "Nombre 63", 1 },
                    { 62, true, "Apellido 62", "+51942024718", "76368697", "paciente62@gmail.com", "Nombre 62", 0 },
                    { 61, true, "Apellido 61", "+51942024717", "76368696", "paciente61@gmail.com", "Nombre 61", 1 },
                    { 60, true, "Apellido 60", "+51942024716", "76368695", "paciente60@gmail.com", "Nombre 60", 0 },
                    { 59, true, "Apellido 59", "+51942024715", "76368694", "paciente59@gmail.com", "Nombre 59", 1 },
                    { 58, true, "Apellido 58", "+51942024714", "76368693", "paciente58@gmail.com", "Nombre 58", 0 },
                    { 57, true, "Apellido 57", "+51942024713", "76368692", "paciente57@gmail.com", "Nombre 57", 1 },
                    { 56, true, "Apellido 56", "+51942024712", "76368691", "paciente56@gmail.com", "Nombre 56", 0 },
                    { 55, true, "Apellido 55", "+51942024711", "76368690", "paciente55@gmail.com", "Nombre 55", 1 },
                    { 54, true, "Apellido 54", "+51942024710", "76368689", "paciente54@gmail.com", "Nombre 54", 0 },
                    { 53, true, "Apellido 53", "+51942024709", "76368688", "paciente53@gmail.com", "Nombre 53", 1 },
                    { 74, true, "Apellido 74", "+51942024730", "76368709", "paciente74@gmail.com", "Nombre 74", 0 },
                    { 52, true, "Apellido 52", "+51942024708", "76368687", "paciente52@gmail.com", "Nombre 52", 0 },
                    { 75, true, "Apellido 75", "+51942024731", "76368710", "paciente75@gmail.com", "Nombre 75", 1 },
                    { 77, true, "Apellido 77", "+51942024733", "76368712", "paciente77@gmail.com", "Nombre 77", 1 },
                    { 98, true, "Apellido 98", "+51942024754", "76368733", "paciente98@gmail.com", "Nombre 98", 0 },
                    { 97, true, "Apellido 97", "+51942024753", "76368732", "paciente97@gmail.com", "Nombre 97", 1 },
                    { 96, true, "Apellido 96", "+51942024752", "76368731", "paciente96@gmail.com", "Nombre 96", 0 },
                    { 95, true, "Apellido 95", "+51942024751", "76368730", "paciente95@gmail.com", "Nombre 95", 1 },
                    { 94, true, "Apellido 94", "+51942024750", "76368729", "paciente94@gmail.com", "Nombre 94", 0 },
                    { 93, true, "Apellido 93", "+51942024749", "76368728", "paciente93@gmail.com", "Nombre 93", 1 },
                    { 92, true, "Apellido 92", "+51942024748", "76368727", "paciente92@gmail.com", "Nombre 92", 0 },
                    { 91, true, "Apellido 91", "+51942024747", "76368726", "paciente91@gmail.com", "Nombre 91", 1 },
                    { 90, true, "Apellido 90", "+51942024746", "76368725", "paciente90@gmail.com", "Nombre 90", 0 },
                    { 89, true, "Apellido 89", "+51942024745", "76368724", "paciente89@gmail.com", "Nombre 89", 1 },
                    { 88, true, "Apellido 88", "+51942024744", "76368723", "paciente88@gmail.com", "Nombre 88", 0 },
                    { 87, true, "Apellido 87", "+51942024743", "76368722", "paciente87@gmail.com", "Nombre 87", 1 },
                    { 86, true, "Apellido 86", "+51942024742", "76368721", "paciente86@gmail.com", "Nombre 86", 0 },
                    { 85, true, "Apellido 85", "+51942024741", "76368720", "paciente85@gmail.com", "Nombre 85", 1 },
                    { 84, true, "Apellido 84", "+51942024740", "76368719", "paciente84@gmail.com", "Nombre 84", 0 },
                    { 83, true, "Apellido 83", "+51942024739", "76368718", "paciente83@gmail.com", "Nombre 83", 1 }
                });

            migrationBuilder.InsertData(
                schema: "Clientes",
                table: "Pacientes",
                columns: new[] { "Id", "Activo", "Apellidos", "Celular", "Dni", "Email", "Nombres", "Sexo" },
                values: new object[,]
                {
                    { 82, true, "Apellido 82", "+51942024738", "76368717", "paciente82@gmail.com", "Nombre 82", 0 },
                    { 81, true, "Apellido 81", "+51942024737", "76368716", "paciente81@gmail.com", "Nombre 81", 1 },
                    { 80, true, "Apellido 80", "+51942024736", "76368715", "paciente80@gmail.com", "Nombre 80", 0 },
                    { 79, true, "Apellido 79", "+51942024735", "76368714", "paciente79@gmail.com", "Nombre 79", 1 },
                    { 78, true, "Apellido 78", "+51942024734", "76368713", "paciente78@gmail.com", "Nombre 78", 0 },
                    { 76, true, "Apellido 76", "+51942024732", "76368711", "paciente76@gmail.com", "Nombre 76", 0 },
                    { 51, true, "Apellido 51", "+51942024707", "76368686", "paciente51@gmail.com", "Nombre 51", 1 },
                    { 50, true, "Apellido 50", "+51942024706", "76368685", "paciente50@gmail.com", "Nombre 50", 0 },
                    { 49, true, "Apellido 49", "+51942024705", "76368684", "paciente49@gmail.com", "Nombre 49", 1 },
                    { 22, true, "Apellido 22", "+51942024678", "76368657", "paciente22@gmail.com", "Nombre 22", 0 },
                    { 21, true, "Apellido 21", "+51942024677", "76368656", "paciente21@gmail.com", "Nombre 21", 1 },
                    { 20, true, "Apellido 20", "+51942024676", "76368655", "paciente20@gmail.com", "Nombre 20", 0 },
                    { 19, true, "Apellido 19", "+51942024675", "76368654", "paciente19@gmail.com", "Nombre 19", 1 },
                    { 18, true, "Apellido 18", "+51942024674", "76368653", "paciente18@gmail.com", "Nombre 18", 0 },
                    { 17, true, "Apellido 17", "+51942024673", "76368652", "paciente17@gmail.com", "Nombre 17", 1 },
                    { 16, true, "Apellido 16", "+51942024672", "76368651", "paciente16@gmail.com", "Nombre 16", 0 },
                    { 15, true, "Apellido 15", "+51942024671", "76368650", "paciente15@gmail.com", "Nombre 15", 1 },
                    { 14, true, "Apellido 14", "+51942024670", "76368649", "paciente14@gmail.com", "Nombre 14", 0 },
                    { 13, true, "Apellido 13", "+51942024669", "76368648", "paciente13@gmail.com", "Nombre 13", 1 },
                    { 12, true, "Apellido 12", "+51942024668", "76368647", "paciente12@gmail.com", "Nombre 12", 0 },
                    { 11, true, "Apellido 11", "+51942024667", "76368646", "paciente11@gmail.com", "Nombre 11", 1 },
                    { 10, true, "Apellido 10", "+51942024666", "76368645", "paciente10@gmail.com", "Nombre 10", 0 },
                    { 9, true, "Apellido 9", "+51942024665", "76368644", "paciente9@gmail.com", "Nombre 9", 1 },
                    { 8, true, "Apellido 8", "+51942024664", "76368643", "paciente8@gmail.com", "Nombre 8", 0 },
                    { 7, true, "Apellido 7", "+51942024663", "76368642", "paciente7@gmail.com", "Nombre 7", 1 },
                    { 6, true, "Apellido 6", "+51942024662", "76368641", "paciente6@gmail.com", "Nombre 6", 0 },
                    { 5, true, "Apellido 5", "+51942024661", "76368640", "paciente5@gmail.com", "Nombre 5", 1 },
                    { 4, true, "Apellido 4", "+51942024660", "76368639", "paciente4@gmail.com", "Nombre 4", 0 },
                    { 3, true, "Apellido 3", "+51942024659", "76368638", "paciente3@gmail.com", "Nombre 3", 1 },
                    { 2, true, "Apellido 2", "+51942024658", "76368637", "paciente2@gmail.com", "Nombre 2", 0 },
                    { 23, true, "Apellido 23", "+51942024679", "76368658", "paciente23@gmail.com", "Nombre 23", 1 },
                    { 24, true, "Apellido 24", "+51942024680", "76368659", "paciente24@gmail.com", "Nombre 24", 0 },
                    { 25, true, "Apellido 25", "+51942024681", "76368660", "paciente25@gmail.com", "Nombre 25", 1 },
                    { 26, true, "Apellido 26", "+51942024682", "76368661", "paciente26@gmail.com", "Nombre 26", 0 },
                    { 48, true, "Apellido 48", "+51942024704", "76368683", "paciente48@gmail.com", "Nombre 48", 0 },
                    { 47, true, "Apellido 47", "+51942024703", "76368682", "paciente47@gmail.com", "Nombre 47", 1 },
                    { 46, true, "Apellido 46", "+51942024702", "76368681", "paciente46@gmail.com", "Nombre 46", 0 },
                    { 45, true, "Apellido 45", "+51942024701", "76368680", "paciente45@gmail.com", "Nombre 45", 1 },
                    { 44, true, "Apellido 44", "+51942024700", "76368679", "paciente44@gmail.com", "Nombre 44", 0 },
                    { 43, true, "Apellido 43", "+51942024699", "76368678", "paciente43@gmail.com", "Nombre 43", 1 },
                    { 42, true, "Apellido 42", "+51942024698", "76368677", "paciente42@gmail.com", "Nombre 42", 0 },
                    { 41, true, "Apellido 41", "+51942024697", "76368676", "paciente41@gmail.com", "Nombre 41", 1 }
                });

            migrationBuilder.InsertData(
                schema: "Clientes",
                table: "Pacientes",
                columns: new[] { "Id", "Activo", "Apellidos", "Celular", "Dni", "Email", "Nombres", "Sexo" },
                values: new object[,]
                {
                    { 40, true, "Apellido 40", "+51942024696", "76368675", "paciente40@gmail.com", "Nombre 40", 0 },
                    { 39, true, "Apellido 39", "+51942024695", "76368674", "paciente39@gmail.com", "Nombre 39", 1 },
                    { 99, true, "Apellido 99", "+51942024755", "76368734", "paciente99@gmail.com", "Nombre 99", 1 },
                    { 38, true, "Apellido 38", "+51942024694", "76368673", "paciente38@gmail.com", "Nombre 38", 0 },
                    { 36, true, "Apellido 36", "+51942024692", "76368671", "paciente36@gmail.com", "Nombre 36", 0 },
                    { 35, true, "Apellido 35", "+51942024691", "76368670", "paciente35@gmail.com", "Nombre 35", 1 },
                    { 34, true, "Apellido 34", "+51942024690", "76368669", "paciente34@gmail.com", "Nombre 34", 0 },
                    { 33, true, "Apellido 33", "+51942024689", "76368668", "paciente33@gmail.com", "Nombre 33", 1 },
                    { 32, true, "Apellido 32", "+51942024688", "76368667", "paciente32@gmail.com", "Nombre 32", 0 },
                    { 31, true, "Apellido 31", "+51942024687", "76368666", "paciente31@gmail.com", "Nombre 31", 1 },
                    { 30, true, "Apellido 30", "+51942024686", "76368665", "paciente30@gmail.com", "Nombre 30", 0 },
                    { 29, true, "Apellido 29", "+51942024685", "76368664", "paciente29@gmail.com", "Nombre 29", 1 },
                    { 28, true, "Apellido 28", "+51942024684", "76368663", "paciente28@gmail.com", "Nombre 28", 0 },
                    { 27, true, "Apellido 27", "+51942024683", "76368662", "paciente27@gmail.com", "Nombre 27", 1 },
                    { 37, true, "Apellido 37", "+51942024693", "76368672", "paciente37@gmail.com", "Nombre 37", 1 },
                    { 100, true, "Apellido 100", "+51942024756", "76368735", "paciente100@gmail.com", "Nombre 100", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes",
                schema: "Clientes");
        }
    }
}
