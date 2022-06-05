using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Identity.Domain
{
    public class Usuario : IdentityUser<int>
    {
        public string NombreCompleto { get; set; }
        public ICollection<RolUsuario> Roles { get; set; }
    }
}
