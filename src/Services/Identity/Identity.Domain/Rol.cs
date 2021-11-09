using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace Identity.Domain
{
    public class Rol : IdentityRole
    {
        public ICollection<RolUsuario> RolesUsuario { get; set; }
    }
}