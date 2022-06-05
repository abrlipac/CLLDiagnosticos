using Microsoft.AspNetCore.Identity;

namespace Identity.Domain
{
    public class RolUsuario : IdentityUserRole<int>
    {
        public Rol Rol { get; set; }
        public Usuario Usuario { get; set; }
    }
}
