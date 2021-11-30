namespace WebClientCore.Models
{
    public class LoginViewModel
    {
        public bool HasInvalidAccess { get; set; }
        public string ReturnBaseUrl { get; set; }
        public UsuarioLogin UsuarioLogin { get; set; }
    }
}