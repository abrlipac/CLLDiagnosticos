using Microsoft.EntityFrameworkCore.Migrations;

namespace Diagnosticos.Persistence.Database.Migrations
{
    public partial class Opciones : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PalabraClave",
                schema: "Diagnosticos",
                table: "Preguntas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CantidadSintomas",
                schema: "Diagnosticos",
                table: "Enfermedades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "NombreClave",
                schema: "Diagnosticos",
                table: "Enfermedades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Tratamiento",
                schema: "Diagnosticos",
                table: "Enfermedades",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                schema: "Diagnosticos",
                table: "Enfermedades",
                columns: new[] { "Id", "CantidadSintomas", "Descripcion", "Nombre", "NombreClave", "Tratamiento" },
                values: new object[,]
                {
                    { 1, 5, "Infección viral común que puede ser mortal, especialmente en grupos de alto riesgo.", "Gripe", "gripe", "La gripe se trata principalmente con descanso y líquidos para que el cuerpo pueda combatir la infección por sí solo. Los analgésicos antiinflamatorios de venta libre pueden ayudar con los síntomas. Una vacuna anual puede prevenir la gripe y limitar sus complicaciones." },
                    { 2, 6, "Es una enfermedad infecciosa causada por un virus de la influenza tipo A. Su morbilidad suele ser alta y su mortalidad baja.", "Gripe A", "gripeA", "Se recomienda el uso de oseltamivir o zanamivir para la prevención y el tratamiento de la infección por los virus de la influenza porcina" },
                    { 3, 5, "Insuficiencia de glóbulos rojos saludables debido a la falta de hierro en el cuerpo.", "Anemia", "anemia", "Utilizar factores de crecimiento como la eritropoyetina permite tratar con gran eficacia muchas formas de anemia. En caso de riesgo de vida, son importantes las transfusiones de concentrados de hematíes provenientes de donaciones." },
                    { 4, 4, "Infección viral contagiosa que se puede prevenir con una vacuna y es conocida por su característico sarpullido rojo.", "Rubéola", "rubeola", "Si bien no hay ningún tratamiento para eliminar una infección establecida, los medicamentos pueden contrarrestar los síntomas. La vacunación puede ayudar a prevenir la enfermedad." },
                    { 5, 5, "Enfermedad viral transmitida por los mosquitos y de prevalencia en las áreas tropicales y subtropicales.", "Dengue", "dengue", "El tratamiento incluye la ingesta de líquidos y el uso de analgésicos. Los casos más graves requieren atención hospitalaria." },
                    { 6, 4, "Infección que inflama los sacos de aire de uno o ambos pulmones, los que pueden llenarse de fluido.", "Neumonía", "neumonia", "Los antibióticos permiten tratar varios tipos de neumonía y algunos pueden prevenirse mediante vacunas." },
                    { 7, 7, "La enfermedad por coronavirus (COVID‑19) es una enfermedad infecciosa provocada por el virus SARS-CoV-2.", "COVID‑19", "covid", "Para proporcionar unos cuidados óptimos, se necesita oxígeno para los pacientes que se encuentran más graves; en pacientes críticos, se requieren respiradores." }
                });

            migrationBuilder.InsertData(
                schema: "Diagnosticos",
                table: "Especialidades",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 4, "Por motivos de prueba.", "General" });

            migrationBuilder.InsertData(
                schema: "Diagnosticos",
                table: "Preguntas",
                columns: new[] { "Id", "Contenido", "Especialidad_Id", "PalabraClave", "TieneOpciones" },
                values: new object[,]
                {
                    { 1, "¿Cual es su temperatura corporal en °C?", 4, "fiebre", false },
                    { 18, "¿Tiene tos que regresa constanmente cada pocos minutos?", 4, "tosconstante", true },
                    { 17, "¿Tiene malestar, dolor leve, ardor o agobio en el pecho?", 4, "dolorpecho", true },
                    { 16, "¿Sufre de dolor en las articulaciones?", 4, "dolorarticulacion", true },
                    { 15, "¿Sufre de brotes temporales de parches de piel enrojecidos, bultos, escamas y picazón?", 4, "erupcionespiel", true },
                    { 14, "¿Tiene los ojos más rojos de lo habitual?", 4, "ojosrojos", true },
                    { 13, "¿Tiene una sensación de tener frío y temblores a pesar de no estar en un lugar frío?", 4, "escalofrios", true },
                    { 12, "¿Tiene dificultad para respirar adecuadamente?", 4, "dificultadrespirar", true },
                    { 11, "¿Se siente cansado y sin ganas de hacer nada?", 4, "cansancio", true },
                    { 10, "¿Ha vomitado en las últimas horas?", 4, "vomito", true },
                    { 9, "¿Ha sufrido de nauseas en las últimas 24 horas?", 4, "nauseas", true },
                    { 8, "¿No tuvo apetito en los últimos 2 días?", 4, "perdidaapetito", true },
                    { 7, "¿Sufre de dolor y malestar en los músculos (ya sea, moderado o intenso)?", 4, "dolormuscular", true },
                    { 6, "¿Sufre de tos con flema?", 4, "tos", true },
                    { 5, "¿Tiene la nariz tapada (congestionada)?", 4, "congestionnasal", true },
                    { 4, "¿Tiene dolor de cabeza? (ya sea, leve o moderado)", 4, "dolorcabeza", true },
                    { 3, "¿Sufre de dolor de garganta?", 4, "dolorgarganta", true },
                    { 2, "¿Tiene una sensación generalizada de molestia?", 4, "malestargeneral", true },
                    { 19, "¿Tiene una temperatura corporal muy alta con escalofríos constantes?", 4, "fiebreescalofrios", true },
                    { 20, "¿Ha perdido sensibilidad en el gusto y no siente olores a su alrededor?", 4, "perdidagustoolfato", true }
                });

            migrationBuilder.InsertData(
                schema: "Diagnosticos",
                table: "Opciones",
                columns: new[] { "Id", "Pregunta_Id", "Valor" },
                values: new object[,]
                {
                    { 1, 2, "Sí" },
                    { 22, 12, "No" },
                    { 23, 13, "Sí" },
                    { 24, 13, "No" },
                    { 25, 14, "Sí" },
                    { 26, 14, "No" },
                    { 27, 15, "Sí" },
                    { 28, 15, "No" },
                    { 29, 16, "Sí" },
                    { 30, 16, "No" },
                    { 31, 17, "Sí" },
                    { 32, 17, "No" },
                    { 33, 18, "Sí" },
                    { 34, 18, "No" },
                    { 35, 19, "Sí" },
                    { 36, 19, "No" },
                    { 21, 12, "Sí" },
                    { 20, 11, "No" },
                    { 19, 11, "Sí" },
                    { 18, 10, "No" },
                    { 2, 2, "No" },
                    { 3, 3, "Sí" },
                    { 4, 3, "No" },
                    { 5, 4, "Sí" },
                    { 6, 4, "No" },
                    { 7, 5, "Sí" },
                    { 8, 5, "No" },
                    { 37, 20, "Sí" },
                    { 9, 6, "Sí" },
                    { 11, 7, "Sí" },
                    { 12, 7, "No" },
                    { 13, 8, "Sí" },
                    { 14, 8, "No" },
                    { 15, 9, "Sí" },
                    { 16, 9, "No" },
                    { 17, 10, "Sí" },
                    { 10, 6, "No" },
                    { 38, 20, "No" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Enfermedades",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Enfermedades",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Enfermedades",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Enfermedades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Enfermedades",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Enfermedades",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Enfermedades",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Opciones",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Preguntas",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                schema: "Diagnosticos",
                table: "Especialidades",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "PalabraClave",
                schema: "Diagnosticos",
                table: "Preguntas");

            migrationBuilder.DropColumn(
                name: "CantidadSintomas",
                schema: "Diagnosticos",
                table: "Enfermedades");

            migrationBuilder.DropColumn(
                name: "NombreClave",
                schema: "Diagnosticos",
                table: "Enfermedades");

            migrationBuilder.DropColumn(
                name: "Tratamiento",
                schema: "Diagnosticos",
                table: "Enfermedades");
        }
    }
}
