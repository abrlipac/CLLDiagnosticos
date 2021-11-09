using Diagnosticos.Persistence.Database;
using Diagnosticos.Service.Queries;
using Diagnosticos.Service.Queries.Exceptions;
using Diagnosticos.Service.Queries.DTOs;
using System;
using TechTalk.SpecFlow;
using Xunit;
using System.Threading.Tasks;
using System.Linq;

namespace Diagnosticos.Bdd.Tests.StepDefinitions
{
    [Binding]
    public class BuscarDiagnosticoSteps
    {
        readonly ScenarioContext Scenario;

        public BuscarDiagnosticoSteps(ScenarioContext scenario)
        {
            Scenario = scenario;
        }

        ApplicationDbContext Context;
        DiagnosticoQueryService Query;
        int IdDiagnostico;
        DiagnosticoDto Result;

        [Given(@"un diagnostico con el Id (.*) agregado en la base de datos")]
        public void GivenUnDiagnosticoConElIdAgregadoEnLaBaseDeDatos(int id)
        {
            Context = ApplicationDbContextInMemory.Get();

            IdDiagnostico = id;

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

            Context.Diagnosticos.Add(diagnostico);
            Context.SaveChanges();
        }
        
        [Given(@"una base de datos que no tiene un diagnostico con Id (.*)")]
        public void GivenUnaBaseDeDatosSinDiagnosticosRegistrados(int id)
        {
            IdDiagnostico = id;

            Context = ApplicationDbContextInMemory.Get();

            if (Context.Diagnosticos.ToList().Exists(x => x.Id == id))
            {
                Context.Diagnosticos.Remove(Context.Diagnosticos.Find(id));
                Context.SaveChanges();
            }
        }
        
        [When(@"se busca el diagnostico por el Id (.*)")]
        public async Task WhenSeBuscaElDiagnosticoPorElId(int id)
        {
            if (IdDiagnostico != id)
                throw new Exception("El Id debería ser 1");

            Query = new DiagnosticoQueryService(Context);

            try
            {
                Result = await Query.GetAsync(IdDiagnostico);
            }
            catch (DiagnosticosGetDiagnosticoException e)
            {
                Scenario.Add("DiagnosticosGetDiagnosticoException", e);
            }
        }
        
        [Then(@"se pueden ver los datos del diagnostico")]
        public void ThenSeMuestranLosDatosDelDiagnostico()
        {
            Assert.Equal(IdDiagnostico, Result.Id);
        }
        
        [Then(@"se muestra un mensaje de error")]
        public void ThenSeMuestraUnMensajeDeError()
        {
            var excepcion = Scenario["DiagnosticosGetDiagnosticoException"];
            Assert.NotNull(excepcion);
        }
    }
}
