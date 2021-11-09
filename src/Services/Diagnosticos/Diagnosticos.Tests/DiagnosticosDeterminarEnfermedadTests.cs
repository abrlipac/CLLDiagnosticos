using Diagnosticos.Service.EventHandlers;
using Diagnosticos.Service.EventHandlers.Commands;
using Diagnosticos.Service.EventHandlers.Exceptions;
using Diagnosticos.Tests.Config;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;

namespace Diagnosticos.Tests
{
    [TestClass]
    public class DiagnosticosDeterminarEnfermedadTests
    {
        private ILogger<DiagnosticoCreateEventHandler> GetLogger
        {
            get
            {
                return new Mock<ILogger<DiagnosticoCreateEventHandler>>()
                    .Object;
            }
        }

        [TestMethod]
        public void GenerarDiagnosticoCuandoExistenDetalles()
        {
            var context = ApplicationDbContextInMemory.Get();

            var eventHandler = new DiagnosticoCreateEventHandler(context, GetLogger);

            string expectedResult = "rubeola";

            var diagnostico = new DiagnosticoCreateCommand
            {
                DetallesDiagnostico = new List<DetalleDiagnosticoCreate>
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
                }
            };

            string actualResult = eventHandler.DeterminarEnfermedad(diagnostico);

            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        [ExpectedException(typeof(DiagnosticosDiagnosticoCreateCommandException))]
        public void GenerarDiagnosticoCuandoNoExistenDetalles()
        {
            var context = ApplicationDbContextInMemory.Get();

            var eventHandler = new DiagnosticoCreateEventHandler(context, GetLogger);

            var diagnostico = new DiagnosticoCreateCommand
            {
                DetallesDiagnostico = new List<DetalleDiagnosticoCreate>()
            };

            eventHandler.DeterminarEnfermedad(diagnostico);
        }
    }
}
