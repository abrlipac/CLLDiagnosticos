using Diagnosticos.Persistence.Database;
using Diagnosticos.Service.Queries;
using Diagnosticos.Service.Queries.DTOs;
using Service.Common.Collection;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Diagnosticos.Bdd.Tests.StepDefinitions
{
    [Binding]
    public class ListarDiagnosticosSteps
    {
        readonly ScenarioContext Scenario;

        public ListarDiagnosticosSteps(ScenarioContext scenario)
        {
            Scenario = scenario;
        }

        ApplicationDbContext Context;
        DiagnosticoQueryService Query;
        DataCollection<DiagnosticoDto> Result;
        int CantidadAListar;

        [Given(@"más de (.*) diagnosticos registrados en la base de datos")]
        public void GivenDiagnosticosRegistradosEnLaBaseDeDatos(int cantidad)
        {
            Context = ApplicationDbContextInMemory.Get();

            Domain.Diagnostico diagnostico = new Domain.Diagnostico()
            {
                Empleado_Id = 1,
                Paciente_Id = 1,
                Fecha = DateTime.UtcNow,
                Enfermedad = "gripe"
            };

            diagnostico.DetallesDiagnostico.Add(
                new Domain.DetalleDiagnostico()
                {
                    Diagnostico = diagnostico,
                    Diagnostico_Id = diagnostico.Id,
                    Sintoma = "tos"
                }
            );

            diagnostico.DetallesDiagnostico.Add(
                new Domain.DetalleDiagnostico()
                {
                    Diagnostico = diagnostico,
                    Diagnostico_Id = diagnostico.Id,
                    Sintoma = "tos"
                }
            );

            // se agregan dos diagnosticos
            for (int i = 0; i < cantidad; i++)
                Context.Diagnosticos.Add(diagnostico);

            Context.SaveChanges();
        }
        
        [Given(@"se especifica que se quieren listar (.*) diagnosticos")]
        public void GivenSeEspecificaQueSeQuierenListarDiagnosticos(int cantidad)
        {
            CantidadAListar = cantidad;
        }
        
        [When(@"se listan los diagnosticos")]
        public async Task WhenSeListanLosDiagnosticos()
        {
            Query = new DiagnosticoQueryService(Context);

            Result = await Query.GetAllAsync(1, CantidadAListar);
        }
        
        [Then(@"se pueden ver los datos de los (.*) diagnosticos")]
        public void ThenSePuedenVerLosDatosDeLosDosDiagnosticos(int cantidad)
        {
            Assert.Equal(cantidad, Result.Items.ToList().Count);
        }
    }
}
