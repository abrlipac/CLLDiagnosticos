using Diagnosticos.Persistence.Database;
using Diagnosticos.Service.EventHandlers;
using Diagnosticos.Service.EventHandlers.Commands;
using Diagnosticos.Service.EventHandlers.Exceptions;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using Xunit;

namespace Diagnosticos.Bdd.Tests.StepDefinitions
{
    [Binding]
    public class CrearDiagnosticoSteps
    {
        readonly ScenarioContext Scenario;

        public CrearDiagnosticoSteps(ScenarioContext scenario)
        {
            Scenario = scenario;
        }

        private ILogger<DiagnosticoCreateEventHandler> GetLogger()
            => new Mock<ILogger<DiagnosticoCreateEventHandler>>().Object;

        readonly ApplicationDbContext Context = ApplicationDbContextInMemory.Get();
        DiagnosticoCreateCommand Diagnostico;
        DiagnosticoCreateEventHandler EventHandler;

        [Given(@"un diagnostico con detalles de diagnostico válidos")]
        public void GivenUnDiagnosticoConDetallesDeDiagnosticoValidos()
        {
            Diagnostico = new DiagnosticoCreateCommand()
            {
                Empleado_Id = 1,
                Paciente_Id = 1,
                DetallesDiagnostico = new List<DetalleDiagnosticoCreate>()
                {
                    new DetalleDiagnosticoCreate() { Sintoma = "tos" }
                }
            };
        }

        [Given(@"un diagnostico con detalles de diagnostico inválidos")]
        public void GivenUnDiagnosticoConDetallesDeDiagnosticoInvalidos()
        {
            Diagnostico = new DiagnosticoCreateCommand()
            {
                Empleado_Id = 1,
                Paciente_Id = 1,
                DetallesDiagnostico = new List<DetalleDiagnosticoCreate>()
                {
                    new DetalleDiagnosticoCreate() { Sintoma = "gripe" }
                }
            };
        }

        [When(@"se intenta agregar el diagnostico a la base de datos")]
        public async Task WhenSeAgregaElDiagnostico()
        {
            EventHandler = new DiagnosticoCreateEventHandler(Context, GetLogger());

            try
            {
                await EventHandler.Handle(Diagnostico, new System.Threading.CancellationToken());
            }
            catch (DiagnosticosDiagnosticoCreateCommandException e)
            {
                Scenario.Add("DiagnosticosDiagnosticoCreateCommandException", e);
            }
        }

        [Then(@"se puede encontrar el diagnostico en la base de datos")]
        public void ThenSePuedeEncontrarElDiagnostico()
        {
            Context.Diagnosticos.ToList().Exists(x => x.Empleado_Id == 1 && x.Paciente_Id == 1 && x.Enfermedad == "gripe");
        }

        [Then(@"muestra un mensaje de error")]
        public void ThenMuestraError()
        {
            var excepcion = Scenario["DiagnosticosDiagnosticoCreateCommandException"];
            Assert.NotNull(excepcion);
        }

    }
}
