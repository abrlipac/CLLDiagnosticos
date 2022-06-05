using Identity.Service.Queries.DTOs;

namespace Identity.Service.Queries.Responses
{
    public class Result
    {
        public bool Succeed { get; set; }
        public UsuarioDto Usuario { get; set; }
        public string Error { get; set; }
    }
}