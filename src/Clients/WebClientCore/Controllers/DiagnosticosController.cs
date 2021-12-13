using Microsoft.AspNetCore.Mvc;
using Refit;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using WebClientCore.Resources;
using WebClientCore.Service;

namespace WebClientCore.Controllers
{
    public class DiagnosticosController : Controller
    {
        private readonly string BaseUrl = ApiUrls.BaseUrl;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Editar()
        {
            return View();
        }

        public async Task<IActionResult> Resultados()
        {
            var refitSettings = new RefitSettings(new NewtonsoftJsonContentSerializer());
            var webClientApi = RestService.For<IWebClientService>(BaseUrl, refitSettings);

            var pacientes = await webClientApi.GetPacientes(GetToken(), GetUserId());
            var pacienteId = pacientes.Items.FirstOrDefault().Id;

            var diagnosticos = await webClientApi.GetDiagnosticos(GetToken());

            var diagnostico = diagnosticos.Items
                .Where(x => x.Paciente_Id == pacienteId)
                .OrderByDescending(x => x.Id)
                .FirstOrDefault();

            diagnostico.PosiblesEnfermedades.OrderByDescending(x => x.Porcentaje);

            return View(diagnostico);
        }
        private string GetUserId1()
            => User.Claims
                .ToList()
                .Where(x => x.Type.Equals(ClaimTypes.NameIdentifier))
                .SingleOrDefault()
                .Value;
        private string GetUserId()
            => "6b445818-0f4b-4227-bd35-f0f9adaf5982";

        private string GetToken1()
            => User.Claims
                .ToList()
                .Where(x => x.Type.Equals("access_token"))
                .SingleOrDefault()
                .Value;
        private string GetToken()
            => "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI2YjQ0NTgxOC0wZjRiLTQyMjctYmQzNS1mMGY5YWRhZjU5ODIiLCJ1bmlxdWVfbmFtZSI6IkFicmFoYW0gTEMiLCJyb2xlIjoiUGFjaWVudGUiLCJuYmYiOjE2Mzk0MzcxNTksImV4cCI6MTYzOTQ0MDc1OSwiaWF0IjoxNjM5NDM3MTU5fQ.wXRMr8FJlEI8C0NYXeZr_D2HQfLUo5iss9S6LTGP6AQ";
    }
}
