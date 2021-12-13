using Api.Gateway.Models.Identity.Commands;

namespace WebClientCore.Models
{
    public class LoginViewModel
    {
        public bool HasInvalidAccess { get; set; }
        public string ReturnBaseUrl { get; set; }
        public UsuarioLoginCommand UsuarioLogin { get; set; }
    }
}