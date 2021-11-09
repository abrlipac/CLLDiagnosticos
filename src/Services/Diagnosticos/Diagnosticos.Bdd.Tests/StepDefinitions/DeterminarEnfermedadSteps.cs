using Diagnosticos.Service.EventHandlers;
using Diagnosticos.Service.EventHandlers.Commands;
using Diagnosticos.Service.EventHandlers.Exceptions;
using Microsoft.Extensions.Logging;
using Moq;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using Xunit;

namespace Diagnosticos.Bdd.Tests.StepDefinitions
{
    [Binding]
    public class DeterminarEnfermedadSteps
    {
        readonly ScenarioContext Scenario;

        public DeterminarEnfermedadSteps(ScenarioContext scenario)
        {
            Scenario = scenario;
        }

        private ILogger<DiagnosticoCreateEventHandler> GetLogger()
            => new Mock<ILogger<DiagnosticoCreateEventHandler>>().Object;

        readonly DiagnosticoCreateCommand Diagnostico = new DiagnosticoCreateCommand();
        DiagnosticoCreateEventHandler EventHandler;

        private string ActualResult;
        private readonly IEnumerable<string> EnfermedadesPredefinidas = new List<string>
        {
            "gripe",
            "gripeA",
            "anemia",
            "rubeola",
            "dengue",
            "neumonia",
            "covid"
        };

        [Given(@"un diagnostico que tiene detalles de diagnostico")]
        public void GivenUnDiagnosticoConDetalles()
        {
            Diagnostico.DetallesDiagnostico = new List<DetalleDiagnosticoCreate>
            {
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "fiebre",
                },
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "escalofrios",
                },
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "dolorcabeza",
                },
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "ojosrojos",
                }
            };
        }

        [Given(@"un diagnostico sin detalles de diagnostico")]
        public void GivenUnDiagnosticoSinDetalles()
        {
            Diagnostico.DetallesDiagnostico = new List<DetalleDiagnosticoCreate>();
        }

        [Given(@"un diagnostico con detalles con sintomas no predefinidos")]
        public void GivenUnDiagnosticoConSintomasNoPredefinidos()
        {
            Diagnostico.DetallesDiagnostico = new List<DetalleDiagnosticoCreate>
            {
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "sueño",
                },
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "hambre",
                },
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "calor",
                }
            };
        }

        [Given(@"un diagnostico que tiene detalles de diagnostico con sintomas de covid")]
        public void GivenUnDiagnosticoConSintomasDeCovid()
        {
            Diagnostico.DetallesDiagnostico = new List<DetalleDiagnosticoCreate>
            {
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "tosseca",
                },
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "cansancio",
                },
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "fiebre",
                },
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "dolormuscular",
                },
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "dolorgarganta",
                },
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "perdidagustoolfato",
                },
                new DetalleDiagnosticoCreate
                {
                    Sintoma = "dificultadrespirar",
                }
            };
        }

        [When(@"se determina la enfermedad")]
        public void WhenSeDeterminaLaEnfermedad()
        {
            var context = ApplicationDbContextInMemory.Get();
            EventHandler = new DiagnosticoCreateEventHandler(context, GetLogger());
            try
            {
                ActualResult = EventHandler.DeterminarEnfermedad(Diagnostico);
            }
            catch (DiagnosticosDiagnosticoCreateCommandException e)
            {
                Scenario.Add("DiagnosticosDiagnosticoCreateCommandException", e);
            }
        }
        
        [Then(@"la enfermedad es una de las predefinidas")]
        public void ThenLaEnfermedadEsPredefinida()
        {
            Assert.Contains(ActualResult, EnfermedadesPredefinidas);
        }

        [Then(@"muestra un error al usuario")]
        public void ThenCapturaExcepcion()
        {
            var excepcion = Scenario["DiagnosticosDiagnosticoCreateCommandException"];
            Assert.NotNull(excepcion);
        }

        [Then(@"la enfermedad es covid")]
        public void ThenLaEnfermedadEsCovid()
        {
            Assert.Equal("covid", ActualResult);
        }
    }
}
