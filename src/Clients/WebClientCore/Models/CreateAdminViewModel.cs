using Api.Gateway.Models.Personal.Commands;

namespace WebClientCore.Models
{
    public class CreateAdminViewModel
    {
        public AdminCreateCommand AdminCreate { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string RepetirPassword { get; set; }
    }
}
