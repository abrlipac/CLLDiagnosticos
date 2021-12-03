using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Clientes.Persistence.Database.Migrations
{
    public partial class Initialize : Migration
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
                    Usuario_Id = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Dni = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Nombres = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Sexo = table.Column<int>(type: "int", nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Activo = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pacientes", x => x.Id);
                });

            migrationBuilder.InsertData(
                schema: "Clientes",
                table: "Pacientes",
                columns: new[] { "Id", "Activo", "Apellidos", "Celular", "Dni", "Email", "FechaNacimiento", "Nombres", "Region", "Sexo", "Usuario_Id" },
                values: new object[,]
                {
                    { 1, true, "Apellido 1", "942024657", "76368636", "paciente1@gmail.com", new DateTime(2003, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 1", "Tacna", 1, "11" },
                    { 73, true, "Apellido 73", "942024729", "76368708", "paciente73@gmail.com", new DateTime(1931, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 73", "Tacna", 1, "83" },
                    { 72, true, "Apellido 72", "942024728", "76368707", "paciente72@gmail.com", new DateTime(1932, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 72", "Puno", 0, "82" },
                    { 71, true, "Apellido 71", "942024727", "76368706", "paciente71@gmail.com", new DateTime(1933, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 71", "Tacna", 1, "81" },
                    { 70, true, "Apellido 70", "942024726", "76368705", "paciente70@gmail.com", new DateTime(1934, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 70", "Arequipa", 0, "80" },
                    { 69, true, "Apellido 69", "942024725", "76368704", "paciente69@gmail.com", new DateTime(1935, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 69", "Tacna", 1, "79" },
                    { 68, true, "Apellido 68", "942024724", "76368703", "paciente68@gmail.com", new DateTime(1936, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 68", "Tacna", 0, "78" },
                    { 67, true, "Apellido 67", "942024723", "76368702", "paciente67@gmail.com", new DateTime(1937, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 67", "Tacna", 1, "77" },
                    { 66, true, "Apellido 66", "942024722", "76368701", "paciente66@gmail.com", new DateTime(1938, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 66", "Puno", 0, "76" },
                    { 65, true, "Apellido 65", "942024721", "76368700", "paciente65@gmail.com", new DateTime(1939, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 65", "Tacna", 1, "75" },
                    { 64, true, "Apellido 64", "942024720", "76368699", "paciente64@gmail.com", new DateTime(1940, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 64", "Tacna", 0, "74" },
                    { 63, true, "Apellido 63", "942024719", "76368698", "paciente63@gmail.com", new DateTime(1941, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 63", "Tacna", 1, "73" },
                    { 62, true, "Apellido 62", "942024718", "76368697", "paciente62@gmail.com", new DateTime(1942, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 62", "Tacna", 0, "72" },
                    { 61, true, "Apellido 61", "942024717", "76368696", "paciente61@gmail.com", new DateTime(1943, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 61", "Tacna", 1, "71" },
                    { 60, true, "Apellido 60", "942024716", "76368695", "paciente60@gmail.com", new DateTime(1944, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 60", "Puno", 0, "70" },
                    { 59, true, "Apellido 59", "942024715", "76368694", "paciente59@gmail.com", new DateTime(1945, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 59", "Tacna", 1, "69" },
                    { 58, true, "Apellido 58", "942024714", "76368693", "paciente58@gmail.com", new DateTime(1946, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 58", "Tacna", 0, "68" },
                    { 57, true, "Apellido 57", "942024713", "76368692", "paciente57@gmail.com", new DateTime(1947, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 57", "Tacna", 1, "67" },
                    { 56, true, "Apellido 56", "942024712", "76368691", "paciente56@gmail.com", new DateTime(1948, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 56", "Tacna", 0, "66" },
                    { 55, true, "Apellido 55", "942024711", "76368690", "paciente55@gmail.com", new DateTime(1949, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 55", "Tacna", 1, "65" },
                    { 54, true, "Apellido 54", "942024710", "76368689", "paciente54@gmail.com", new DateTime(1950, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 54", "Puno", 0, "64" },
                    { 53, true, "Apellido 53", "942024709", "76368688", "paciente53@gmail.com", new DateTime(1951, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 53", "Tacna", 1, "63" },
                    { 74, true, "Apellido 74", "942024730", "76368709", "paciente74@gmail.com", new DateTime(1930, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 74", "Tacna", 0, "84" },
                    { 52, true, "Apellido 52", "942024708", "76368687", "paciente52@gmail.com", new DateTime(1952, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 52", "Tacna", 0, "62" },
                    { 75, true, "Apellido 75", "942024731", "76368710", "paciente75@gmail.com", new DateTime(1929, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 75", "Tacna", 1, "85" },
                    { 77, true, "Apellido 77", "942024733", "76368712", "paciente77@gmail.com", new DateTime(1927, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 77", "Tacna", 1, "87" },
                    { 98, true, "Apellido 98", "942024754", "76368733", "paciente98@gmail.com", new DateTime(1906, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 98", "Tacna", 0, "108" },
                    { 97, true, "Apellido 97", "942024753", "76368732", "paciente97@gmail.com", new DateTime(1907, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 97", "Tacna", 1, "107" },
                    { 96, true, "Apellido 96", "942024752", "76368731", "paciente96@gmail.com", new DateTime(1908, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 96", "Puno", 0, "106" },
                    { 95, true, "Apellido 95", "942024751", "76368730", "paciente95@gmail.com", new DateTime(1909, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 95", "Tacna", 1, "105" },
                    { 94, true, "Apellido 94", "942024750", "76368729", "paciente94@gmail.com", new DateTime(1910, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 94", "Tacna", 0, "104" },
                    { 93, true, "Apellido 93", "942024749", "76368728", "paciente93@gmail.com", new DateTime(1911, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 93", "Tacna", 1, "103" },
                    { 92, true, "Apellido 92", "942024748", "76368727", "paciente92@gmail.com", new DateTime(1912, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 92", "Tacna", 0, "102" },
                    { 91, true, "Apellido 91", "942024747", "76368726", "paciente91@gmail.com", new DateTime(1913, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 91", "Tacna", 1, "101" },
                    { 90, true, "Apellido 90", "942024746", "76368725", "paciente90@gmail.com", new DateTime(1914, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 90", "Puno", 0, "100" },
                    { 89, true, "Apellido 89", "942024745", "76368724", "paciente89@gmail.com", new DateTime(1915, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 89", "Tacna", 1, "99" },
                    { 88, true, "Apellido 88", "942024744", "76368723", "paciente88@gmail.com", new DateTime(1916, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 88", "Tacna", 0, "98" },
                    { 87, true, "Apellido 87", "942024743", "76368722", "paciente87@gmail.com", new DateTime(1917, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 87", "Tacna", 1, "97" },
                    { 86, true, "Apellido 86", "942024742", "76368721", "paciente86@gmail.com", new DateTime(1918, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 86", "Tacna", 0, "96" },
                    { 85, true, "Apellido 85", "942024741", "76368720", "paciente85@gmail.com", new DateTime(1919, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 85", "Tacna", 1, "95" },
                    { 84, true, "Apellido 84", "942024740", "76368719", "paciente84@gmail.com", new DateTime(1920, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 84", "Puno", 0, "94" },
                    { 83, true, "Apellido 83", "942024739", "76368718", "paciente83@gmail.com", new DateTime(1921, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 83", "Tacna", 1, "93" }
                });

            migrationBuilder.InsertData(
                schema: "Clientes",
                table: "Pacientes",
                columns: new[] { "Id", "Activo", "Apellidos", "Celular", "Dni", "Email", "FechaNacimiento", "Nombres", "Region", "Sexo", "Usuario_Id" },
                values: new object[,]
                {
                    { 82, true, "Apellido 82", "942024738", "76368717", "paciente82@gmail.com", new DateTime(1922, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 82", "Tacna", 0, "92" },
                    { 81, true, "Apellido 81", "942024737", "76368716", "paciente81@gmail.com", new DateTime(1923, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 81", "Tacna", 1, "91" },
                    { 80, true, "Apellido 80", "942024736", "76368715", "paciente80@gmail.com", new DateTime(1924, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 80", "Arequipa", 0, "90" },
                    { 79, true, "Apellido 79", "942024735", "76368714", "paciente79@gmail.com", new DateTime(1925, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 79", "Tacna", 1, "89" },
                    { 78, true, "Apellido 78", "942024734", "76368713", "paciente78@gmail.com", new DateTime(1926, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 78", "Puno", 0, "88" },
                    { 76, true, "Apellido 76", "942024732", "76368711", "paciente76@gmail.com", new DateTime(1928, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 76", "Tacna", 0, "86" },
                    { 51, true, "Apellido 51", "942024707", "76368686", "paciente51@gmail.com", new DateTime(1953, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 51", "Tacna", 1, "61" },
                    { 50, true, "Apellido 50", "942024706", "76368685", "paciente50@gmail.com", new DateTime(1954, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 50", "Arequipa", 0, "60" },
                    { 49, true, "Apellido 49", "942024705", "76368684", "paciente49@gmail.com", new DateTime(1955, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 49", "Tacna", 1, "59" },
                    { 22, true, "Apellido 22", "942024678", "76368657", "paciente22@gmail.com", new DateTime(1982, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 22", "Tacna", 0, "32" },
                    { 21, true, "Apellido 21", "942024677", "76368656", "paciente21@gmail.com", new DateTime(1983, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 21", "Tacna", 1, "31" },
                    { 20, true, "Apellido 20", "942024676", "76368655", "paciente20@gmail.com", new DateTime(1984, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 20", "Arequipa", 0, "30" },
                    { 19, true, "Apellido 19", "942024675", "76368654", "paciente19@gmail.com", new DateTime(1985, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 19", "Tacna", 1, "29" },
                    { 18, true, "Apellido 18", "942024674", "76368653", "paciente18@gmail.com", new DateTime(1986, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 18", "Puno", 0, "28" },
                    { 17, true, "Apellido 17", "942024673", "76368652", "paciente17@gmail.com", new DateTime(1987, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 17", "Tacna", 1, "27" },
                    { 16, true, "Apellido 16", "942024672", "76368651", "paciente16@gmail.com", new DateTime(1988, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 16", "Tacna", 0, "26" },
                    { 15, true, "Apellido 15", "942024671", "76368650", "paciente15@gmail.com", new DateTime(1989, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 15", "Tacna", 1, "25" },
                    { 14, true, "Apellido 14", "942024670", "76368649", "paciente14@gmail.com", new DateTime(1990, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 14", "Tacna", 0, "24" },
                    { 13, true, "Apellido 13", "942024669", "76368648", "paciente13@gmail.com", new DateTime(1991, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 13", "Tacna", 1, "23" },
                    { 12, true, "Apellido 12", "942024668", "76368647", "paciente12@gmail.com", new DateTime(1992, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 12", "Puno", 0, "22" },
                    { 11, true, "Apellido 11", "942024667", "76368646", "paciente11@gmail.com", new DateTime(1993, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 11", "Tacna", 1, "21" },
                    { 10, true, "Apellido 10", "942024666", "76368645", "paciente10@gmail.com", new DateTime(1994, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 10", "Arequipa", 0, "20" },
                    { 9, true, "Apellido 9", "942024665", "76368644", "paciente9@gmail.com", new DateTime(1995, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 9", "Tacna", 1, "19" },
                    { 8, true, "Apellido 8", "942024664", "76368643", "paciente8@gmail.com", new DateTime(1996, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 8", "Tacna", 0, "18" },
                    { 7, true, "Apellido 7", "942024663", "76368642", "paciente7@gmail.com", new DateTime(1997, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 7", "Tacna", 1, "17" },
                    { 6, true, "Apellido 6", "942024662", "76368641", "paciente6@gmail.com", new DateTime(1998, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 6", "Puno", 0, "16" },
                    { 5, true, "Apellido 5", "942024661", "76368640", "paciente5@gmail.com", new DateTime(1999, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 5", "Tacna", 1, "15" },
                    { 4, true, "Apellido 4", "942024660", "76368639", "paciente4@gmail.com", new DateTime(2000, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 4", "Tacna", 0, "14" },
                    { 3, true, "Apellido 3", "942024659", "76368638", "paciente3@gmail.com", new DateTime(2001, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 3", "Tacna", 1, "13" },
                    { 2, true, "Apellido 2", "942024658", "76368637", "paciente2@gmail.com", new DateTime(2002, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 2", "Tacna", 0, "12" },
                    { 23, true, "Apellido 23", "942024679", "76368658", "paciente23@gmail.com", new DateTime(1981, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 23", "Tacna", 1, "33" },
                    { 24, true, "Apellido 24", "942024680", "76368659", "paciente24@gmail.com", new DateTime(1980, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 24", "Puno", 0, "34" },
                    { 25, true, "Apellido 25", "942024681", "76368660", "paciente25@gmail.com", new DateTime(1979, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 25", "Tacna", 1, "35" },
                    { 26, true, "Apellido 26", "942024682", "76368661", "paciente26@gmail.com", new DateTime(1978, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 26", "Tacna", 0, "36" },
                    { 48, true, "Apellido 48", "942024704", "76368683", "paciente48@gmail.com", new DateTime(1956, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 48", "Puno", 0, "58" },
                    { 47, true, "Apellido 47", "942024703", "76368682", "paciente47@gmail.com", new DateTime(1957, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 47", "Tacna", 1, "57" },
                    { 46, true, "Apellido 46", "942024702", "76368681", "paciente46@gmail.com", new DateTime(1958, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 46", "Tacna", 0, "56" },
                    { 45, true, "Apellido 45", "942024701", "76368680", "paciente45@gmail.com", new DateTime(1959, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 45", "Tacna", 1, "55" },
                    { 44, true, "Apellido 44", "942024700", "76368679", "paciente44@gmail.com", new DateTime(1960, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 44", "Tacna", 0, "54" },
                    { 43, true, "Apellido 43", "942024699", "76368678", "paciente43@gmail.com", new DateTime(1961, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 43", "Tacna", 1, "53" },
                    { 42, true, "Apellido 42", "942024698", "76368677", "paciente42@gmail.com", new DateTime(1962, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 42", "Puno", 0, "52" },
                    { 41, true, "Apellido 41", "942024697", "76368676", "paciente41@gmail.com", new DateTime(1963, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 41", "Tacna", 1, "51" }
                });

            migrationBuilder.InsertData(
                schema: "Clientes",
                table: "Pacientes",
                columns: new[] { "Id", "Activo", "Apellidos", "Celular", "Dni", "Email", "FechaNacimiento", "Nombres", "Region", "Sexo", "Usuario_Id" },
                values: new object[,]
                {
                    { 40, true, "Apellido 40", "942024696", "76368675", "paciente40@gmail.com", new DateTime(1964, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 40", "Arequipa", 0, "50" },
                    { 39, true, "Apellido 39", "942024695", "76368674", "paciente39@gmail.com", new DateTime(1965, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 39", "Tacna", 1, "49" },
                    { 99, true, "Apellido 99", "942024755", "76368734", "paciente99@gmail.com", new DateTime(1905, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 99", "Tacna", 1, "109" },
                    { 38, true, "Apellido 38", "942024694", "76368673", "paciente38@gmail.com", new DateTime(1966, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 38", "Tacna", 0, "48" },
                    { 36, true, "Apellido 36", "942024692", "76368671", "paciente36@gmail.com", new DateTime(1968, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 36", "Puno", 0, "46" },
                    { 35, true, "Apellido 35", "942024691", "76368670", "paciente35@gmail.com", new DateTime(1969, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 35", "Tacna", 1, "45" },
                    { 34, true, "Apellido 34", "942024690", "76368669", "paciente34@gmail.com", new DateTime(1970, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 34", "Tacna", 0, "44" },
                    { 33, true, "Apellido 33", "942024689", "76368668", "paciente33@gmail.com", new DateTime(1971, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 33", "Tacna", 1, "43" },
                    { 32, true, "Apellido 32", "942024688", "76368667", "paciente32@gmail.com", new DateTime(1972, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 32", "Tacna", 0, "42" },
                    { 31, true, "Apellido 31", "942024687", "76368666", "paciente31@gmail.com", new DateTime(1973, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 31", "Tacna", 1, "41" },
                    { 30, true, "Apellido 30", "942024686", "76368665", "paciente30@gmail.com", new DateTime(1974, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 30", "Puno", 0, "40" },
                    { 29, true, "Apellido 29", "942024685", "76368664", "paciente29@gmail.com", new DateTime(1975, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 29", "Tacna", 1, "39" },
                    { 28, true, "Apellido 28", "942024684", "76368663", "paciente28@gmail.com", new DateTime(1976, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 28", "Tacna", 0, "38" },
                    { 27, true, "Apellido 27", "942024683", "76368662", "paciente27@gmail.com", new DateTime(1977, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 27", "Tacna", 1, "37" },
                    { 37, true, "Apellido 37", "942024693", "76368672", "paciente37@gmail.com", new DateTime(1967, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 37", "Tacna", 1, "47" },
                    { 100, true, "Apellido 100", "942024756", "76368735", "paciente100@gmail.com", new DateTime(1904, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Nombre 100", "Arequipa", 0, "110" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Dni",
                schema: "Clientes",
                table: "Pacientes",
                column: "Dni",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_Usuario_Id",
                schema: "Clientes",
                table: "Pacientes",
                column: "Usuario_Id",
                unique: true,
                filter: "[Usuario_Id] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pacientes",
                schema: "Clientes");
        }
    }
}
